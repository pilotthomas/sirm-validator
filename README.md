# SirmValidator (AIRR Validator)

> A Windows Forms desktop tool for inspecting, validating, and resolving scanned TIFF documents flowing through the **SIRM ➜ ImageIO ➜ Doclink (EDM)** pipeline at Maxum / SPI.


|                             |                                               |
| --------------------------- | --------------------------------------------- |
| **Assembly**                | `SirmValidator.exe`                           |
| **Display name**            | AIRR Validator                                |
| **Root namespace**          | `Maxum`                                       |
| **Target framework**        | .NET Framework 4.0                            |
| **Output type**             | `WinExe` (Windows Forms)                      |
| **Platform target (Debug)** | `x86`                                         |
| **Author / Owner**          | Bill Wood — Maxum Petroleum (© 2012)          |
| **SQL Server**              | `SPIS470` (database `Common`)                 |
| **WCF endpoint**            | `net.tcp://MSS300:9051/DoclinkMonitorService` |
| **Distribution**            | ClickOnce — `\\spis420\Maxum\SirmValidator2\` |


For deeper architecture, workflows, and screenshots, see `[SirmValidator_Confluence.md](./SirmValidator_Confluence.md)`.

---

## Table of Contents

1. [What it does](#1-what-it-does)
2. [Prerequisites](#2-prerequisites)
3. [Project structure](#3-project-structure)
4. [Build](#4-build)
5. [Configuration](#5-configuration)
6. [Run](#6-run)
7. [Operator workflows](#7-operator-workflows)
8. [Database objects used](#8-database-objects-used)
9. [Service operations consumed](#9-service-operations-consumed)
10. [Deployment (ClickOnce)](#10-deployment-clickonce)
11. [Troubleshooting](#11-troubleshooting)
12. [Known limitations](#12-known-limitations)
13. [Contacts](#13-contacts)

---

## 1. What it does

`SirmValidator` is the **triage and validation tool** for scanned TIFFs in the SIRM/Doclink pipeline. It does four things:

1. **Look up a file** by Filename or DocumentID — see every Doclink record + every Collator/Unknown record for it, view the underlying TIFF, copy pages to the clipboard. *(Main form: `frmGetFileDocInfo`.)*
2. **Audit the ImageIO exception queue** — list every problem message and either **Resubmit** (move file back to `SirmNew`), **Manual Validate** (force-mark all flags `True`), or just **Find** the file in the archive. *(Admin form: `frmAudit`, gated by an admin whitelist.)*
3. **Birds-Eye-View report** — date-range grouped report of everything indexed into Doclink, with image preview. *(Form: `frmProcessAnalysis`.)*
4. **Headless auto-resolve** — `SirmValidator.exe Auto` runs without UI and silently dismisses ImageIO exceptions whose underlying files are clearly fine.

> One-line summary: **a triage / validation utility for scanned-TIFF documents in the Maxum SIRM ➜ Doclink pipeline.**

---

## 2. Prerequisites

### To run

- Windows with **.NET Framework 4.0** (x86 launch).
- Network access to:
  - `SPIS470` (SQL Server, integrated security).
  - `MSS300:9051` (WCF NetTcp endpoint).
  - `\\spis420\` file shares (SIRM Archive / Extended Archive / New / Completed).
- A **Windows account** that has SQL `EXECUTE` rights on the three stored procedures listed in [§8](#8-database-objects-used) and is allowed to call `DoclinkMonitorService`.
- (Optional) Membership in the admin whitelist (`SUser` setting) to see the **Admin → Audit** menu.

### To build

- **Visual Studio 2010 or later** (the solution format is VS2010, but it opens cleanly in VS2012–2022).
- VB.NET compiler with `.NET Framework 4.0 Targeting Pack` installed.
- ComponentOne assemblies (already checked in next to the `.vbproj`):
  - `C1.Win.C1Input.2.dll` v2.0.20133.33326
  - `C1.Win.C1TrueDBGrid.2.dll` v2.0.20133.61335
- The Doclink WCF proxy DLL referenced via `HintPath`:
  - `..\DoclinkMonitorWCF\DoclinkMonitorProxy\DLL\DoclinkMonitorProxy.dll`
  - i.e. you also need the sibling solution **DoclinkMonitorWCF** checked out next to this one.

---

## 3. Project structure

```text
SirmValidator/
├── SirmValidator.sln
├── SirmValidator.vbproj
├── app.config                                  # SQL conn strings + WCF bindings
│
├── modMain.vb                                  # STAThread Main; "Auto" CLI handling
├── ApplicationEvents.vb                        # (empty)
│
├── Forms
│   ├── frmGetFileDocInfo.vb / .Designer.vb     # Main "AIRR Validator" window
│   ├── frmAudit.vb           / .Designer.vb    # Admin → Audit
│   ├── frmProcessAnalysis.vb / .Designer.vb    # Birds Eye View
│   └── Form1.vb              / .Designer.vb    # Legacy form (almost fully commented out)
│
├── Data layer
│   ├── Data.vb                                 # ValidatorData singleton (WCF wrapper)
│   ├── SirmPaths.vb                            # Paths singleton (DB-driven)
│   ├── CommonDataSet.xsd / .Designer.vb / .vb  # Typed dataset for 3 stored procs
│   ├── Automation.vb                           # Older AutoResolve (unused)
│   ├── invoices.vb / ta.vb                     # Legacy xsd.exe-generated (unused)
│
├── TIFF utilities
│   ├── TiffEncoderDecoder.vb                   # WPF-imaging based (active)
│   └── TiffSplitter.vb                         # SPI.Graphics.TiffManager + MSMQ (legacy)
│
├── Resources & 3rd-party
│   ├── C1.Win.C1Input.2.dll
│   ├── C1.Win.C1TrueDBGrid.2.dll
│   ├── Service References/                     # WCF generated proxies
│   ├── Resources/                              # icons / bitmaps
│   ├── search4files.ico
│   └── 20052876-...tif                         # sample TIFF
│
├── My Project/
│   ├── AssemblyInfo.vb                         # Title, version, GUID, copyright
│   ├── Application.myapp / Application.Designer.vb
│   ├── app.manifest
│   ├── Settings.settings / Settings.Designer.vb # SUser whitelist + conn strings
│   ├── Resources.resx / Resources.Designer.vb
│   └── DataSources/...
│
├── Collator_TemporaryKey.pfx                    # ClickOnce manifest signing key
├── README.md                                    # ← you are here
└── SirmValidator_Confluence.md                  # Detailed architecture + workflows
```

---

## 4. Build

### Visual Studio

1. Open `SirmValidator.sln`.
2. Make sure the sibling `DoclinkMonitorWCF` repo is cloned next to this one so `..\DoclinkMonitorWCF\DoclinkMonitorProxy\DLL\DoclinkMonitorProxy.dll` resolves.
3. **Build** ➜ `Debug | Any CPU` (which builds as `x86`) or `Release | Any CPU`.
4. Output:
  - `bin\Debug\SirmValidator.exe` — Debug
  - `bin\Release\SirmValidator.exe` — Release

### Command line (MSBuild)

```powershell
# From a Visual Studio Developer Command Prompt
msbuild SirmValidator.vbproj /p:Configuration=Release /p:Platform="AnyCPU"
```

> ⚠️ Some warnings are intentionally suppressed via the `<NoWarn>` list in the `.vbproj` (e.g. 41999, 42016–42022, 42032, 42036, 42353–42355). Don't be alarmed.

---

## 5. Configuration

### `app.config`


| Key                                          | Purpose                                                                                               |
| -------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `Maxum.My.MySettings.CommonConnectionString` | `Data Source=SPIS470;Initial Catalog=Common;Integrated Security=True;Application Name=SirmValidator2` |
| `Maxum.My.MySettings.ConnectionString`       | `Data Source=spis470;Integrated Security=True;MultipleActiveResultSets=True`                          |
| `system.serviceModel/client/endpoint`        | `net.tcp://MSS300:9051/DoclinkMonitorService` (binding `NetTcpBinding_IDoclinkMonitorService`)        |
| `applicationSettings ➜ SUser`                | List of admin Windows usernames (lower-case): `bill`, `brian`, `paul`                                 |
| `system.diagnostics ➜ FileLog`               | Microsoft.VisualBasic `FileLogTraceListener` (init data `FileLogWriter`)                              |


Logs are written by `My.Application.Log` and the `FileLogTraceListener`. By default they end up under:

```text
%LOCALAPPDATA%\Bill Wood\SirmValidator_<hash>\<version>\FileLogWriter.log
```

(adjust per machine — the exact path is `My.Application.Log.DefaultFileLogWriter.FullLogFileName`).

### SIRM folder paths (loaded from DB at runtime)

There is **no path config in `app.config`** — `SirmPaths` reads them from the stored procedure `dbo.ListSirmPaths` on first access:


| Row name              | Purpose                                                       |
| --------------------- | ------------------------------------------------------------- |
| `SirmArchive`         | Where SIRM keeps the originals.                               |
| `SirmExtendedArchive` | Older / overflow archive (fallback search location).          |
| `SirmNew`             | The "Recognize" drop folder — Resubmit moves files back here. |
| `SirmCompleted`       | Reserved (declared but not currently consumed).               |


> Changing these paths only requires updating the DB rows and restarting the app — no rebuild needed.

### Admin whitelist (`SUser`)

Used by `frmGetFileDocInfo.New()`:

```vb
Dim usr As String = My.User.Name.Substring(My.User.Name.IndexOf("\") + 1)
AdminToolStripMenuItem.Visible = My.Settings.SUser.Contains(usr.ToLower)
```

To grant a user the **Admin → Audit** menu, add their account name (without the domain prefix, lower-case) to `SUser` in `app.config` and redeploy, **or** override it in the per-user `user.config`.

---

## 6. Run

### Interactive mode

```powershell
SirmValidator.exe
```

Launches `frmGetFileDocInfo` ("AIRR Validator").

### Headless auto-resolve mode

```powershell
SirmValidator.exe Auto
```

- Runs `modMain.AutoResolve` once and exits.
- Pulls the ImageIO exception queue, filters rows older than 15 minutes, and force-validates rows whose underlying file is clearly fine.
- Intended to be wired up via **Windows Task Scheduler**.
- Exceptions are silently swallowed (see [Known limitations](#12-known-limitations)) — check the trace log if it doesn't seem to be doing anything.

#### Sample Scheduled Task (XML snippet)

```xml
<Actions>
  <Exec>
    <Command>C:\Program Files\Maxum\SirmValidator2\SirmValidator.exe</Command>
    <Arguments>Auto</Arguments>
  </Exec>
</Actions>
<Triggers>
  <CalendarTrigger>
    <Repetition>
      <Interval>PT15M</Interval>
    </Repetition>
    <StartBoundary>2026-01-01T00:00:00</StartBoundary>
  </CalendarTrigger>
</Triggers>
```

---

## 7. Operator workflows

### A. "Where is my file?"

1. Open the app.
2. Type the filename (or DocumentID) in **File Name or DocumentID**.
3. Click **Get Info**.
4. Read the summary in the info text box; click any row in the list to view the corresponding TIFF.
5. (Optional) Click **View Original Archived File** to open the original from `SirmArchive` / `SirmExtendedArchive`.
6. (Optional) Right-click the image → **Copy Image** / **Copy All Images** to put TIFFs on the clipboard.

### B. Clearing the ImageIO exception queue (admin)

1. Menu **Admin → Audit**.
2. Click **Refresh** (or wait — async load auto-fires on form open).
3. Apply filters: *File not processed* / *Image not processed* / *EDM not verified* / *Overdue*.
4. For each row:
  - **Find** — does the file still exist?
  - **Resubmit** — move it back to `SirmNew` for re-recognition.
  - **Manual Validate** — set `FileProcessed = ImagesProcessed = EdmVerified = True`.
5. Tick **Show Image** to mirror the selected file in the main form.

### C. Birds-Eye-View report

1. Menu **Birds Eye View** (opens `frmProcessAnalysis`).
2. Pick **Start** and **End** dates (defaults: today / tomorrow).
3. Click the call button to fill the grid.
4. Use **GroupBy → Default** or **GroupBy → IndexedBy** for grouping.
5. Tick **View Image** + scroll rows to preview each file.
6. Type into the column filter row — `*` is auto-inserted around literals so substring search just works.

---

## 8. Database objects used

All on `SPIS470.Common`:


| Stored procedure                     | Parameters                                 | Used by                                                  |
| ------------------------------------ | ------------------------------------------ | -------------------------------------------------------- |
| `dbo.GetDocumentInfoFromFile`        | `@Filename varchar(255)`                   | `frmGetFileDocInfo` (main lookup), `modMain.AutoResolve` |
| `dbo.ListImageIO_IndexedIntoDoclink` | `@StartDate datetime`, `@EndDate datetime` | `frmProcessAnalysis`                                     |
| `dbo.ListSirmPaths`                  | *(none)*                                   | `SirmPaths` singleton (paths cache)                      |


The columns each procedure must return are pinned in `CommonDataSet.xsd`. Changing a column name on the SQL side without regenerating the typed DataSet **will break runtime data binding**.

---

## 9. Service operations consumed

WCF service: `Maxum.EDM.Utilities.DoclinkMonitorService.IDoclinkMonitorService` (NetTcp, Transport security, Windows credentials).


| Operation                                                          | Used in                                                         | Purpose                                      |
| ------------------------------------------------------------------ | --------------------------------------------------------------- | -------------------------------------------- |
| `ListDocumentExceptionsData()` / `Begin… / End…`                   | `ValidatorData.GetAuditData(Async)`                             | Pull current ImageIO exception queue.        |
| `SetImageIoFlags(id, fileProcessed, imagesProcessed, edmVerified)` | `frmAudit.ManualValidateButton_Click`, `modMain.ManualValidate` | Force-mark a queue entry as fully validated. |


Binding limits: `maxBufferSize` / `maxReceivedMessageSize` = **256 MB**, `receiveTimeout` = 10 min, `sendTimeout` = 1 min.

---

## 10. Deployment (ClickOnce)


| Property                        | Value                                               |
| ------------------------------- | --------------------------------------------------- |
| `PublishUrl`                    | `\\spis420\Maxum\SirmValidator2\`                   |
| `InstallFrom`                   | `Unc`                                               |
| `UpdateEnabled`                 | `true`                                              |
| `UpdateMode`                    | `Foreground`                                        |
| `UpdateInterval`                | `7 Days`                                            |
| `UpdateRequired`                | `false`                                             |
| `ApplicationVersion`            | `2.0.0.*`                                           |
| `ApplicationRevision`           | `6`                                                 |
| `ManifestKeyFile`               | `Collator_TemporaryKey.pfx`                         |
| `ManifestCertificateThumbprint` | `A365606A5DD3DF428816EFDBC6524B3B472FE012`          |
| `SignManifests`                 | `false`                                             |
| Bootstrappers                   | .NET Framework 4 (x86 + x64), Windows Installer 4.5 |


To publish a new version from Visual Studio: **Project → Publish…** (the `Publish Wizard Completed` flag in the `.vbproj` is already `true`, so the wizard's last setting will be reused).

---

## 11. Troubleshooting


| Symptom                                                                    | Likely cause                                                              | What to check                                                                                                                              |
| -------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| **Admin menu is missing**                                                  | Your Windows account isn't in `SUser`.                                    | `app.config` ➜ `applicationSettings ➜ SUser`. Add your username (lower-case, no domain) and redeploy, or edit your per-user `user.config`. |
| **"Cant find archived file."** when clicking *View Original Archived File* | TIFF isn't in either archive folder.                                      | Verify `SirmArchive` / `SirmExtendedArchive` row values via `dbo.ListSirmPaths`; verify share access.                                      |
| `**Get Info` returns "Nothing was found."**                                | Filename mismatch (the SP looks up by exact name).                        | If the input has no extension, the form auto-appends `.Tif` — confirm casing and that the file was actually received by SIRM.              |
| **Audit grid stays empty**                                                 | WCF call to `MSS300:9051` failed silently.                                | Check the trace log (`FileLogWriter.log`); confirm the service is up and the firewall allows the NetTcp port.                              |
| `**SirmValidator.exe Auto` does nothing**                                  | Exception swallowed in `Try/Catch` of `modMain`.                          | Inspect `FileLogWriter.log`; check that `dbo.GetDocumentInfoFromFile` and `SetImageIoFlags` permissions are granted.                       |
| **Rotation not saved**                                                     | By design — `tsmiRotate` only rotates the in-memory bitmap, not the file. | Use a TIFF editor or extend the code if persistence is required.                                                                           |
| **App memory keeps growing**                                               | TIFF release timer disabled or images held open.                          | Click **Release Image**, or wait 2 min (10 min in archive mode) for the timer to dispose `PictureBox1.Image`.                              |
| **Build error: cannot find `DoclinkMonitorProxy.dll`**                     | Sibling repo not cloned.                                                  | Clone `DoclinkMonitorWCF` next to `SirmValidator` so `..\DoclinkMonitorWCF\DoclinkMonitorProxy\DLL\DoclinkMonitorProxy.dll` resolves.      |
| **Build error: cannot find `C1.Win.*.dll`**                                | Repo not fully checked out.                                               | These DLLs sit beside the `.vbproj`. Make sure they're present (they're tracked in source control).                                        |


---

*© Maxum Petroleum 2012. Internal use only.*