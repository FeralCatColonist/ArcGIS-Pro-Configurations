# ArcPSL Pro — Getting Started

ArcPSL Pro is a seasonal theme for ArcGIS Pro. It replaces the splash screen and start page with custom branded artwork. Everything else — your projects, data, and tools — works exactly as it does in standard ArcGIS Pro.

---

## Requirements

- ArcGIS Pro 3.5 or later (any edition, any license level)
- Windows 10 or Windows 11

---

## Step 1: Install the Configuration File

1. Locate the `.proConfigX` file you received (e.g., `ArcPSLPro.proConfigX`).
2. Open Windows Explorer and navigate to:
   ```
   %USERPROFILE%\Documents\ArcGIS\AddIns\ArcGISPro\Configurations
   ```
   Paste this path directly into the Explorer address bar — Windows will expand `%USERPROFILE%` to your user folder automatically.
3. If the `Configurations` folder does not exist, create it.
4. Copy `ArcPSLPro.proConfigX` into this folder.

---

## Step 2: Launch ArcPSL Pro

ArcPSL Pro must be launched with a special command-line flag — it does not replace your standard ArcGIS Pro shortcut.

**Option A — Command line (one-time test):**

Open PowerShell or Command Prompt and run:

```
"C:\Program Files\ArcGIS\Pro\bin\ArcGISPro.exe" /config:ArcPSLPro
```

If ArcGIS Pro is installed in a non-default location, adjust the path accordingly.

**Option B — Desktop shortcut (recommended for daily use):**

1. Right-click your desktop → **New** → **Shortcut**
2. In the location field, paste:
   ```
   "C:\Program Files\ArcGIS\Pro\bin\ArcGISPro.exe" /config:ArcPSLPro
   ```
3. Name the shortcut **ArcPSL Pro**
4. Click Finish

---

## Step 3: What to Expect

When the configuration loads, you will see:

- **Splash screen:** Seasonal artwork with an animated "Initializing" loading indicator
- **Start page:** The ArcPSL Pro branded start page with a seasonal background

From here, use ArcGIS Pro exactly as you normally would — open projects, create new maps, access your tools and data.

---

## Troubleshooting

### The standard ArcGIS Pro splash screen appears instead of the seasonal one

The most common cause is that an ArcGIS Pro window is already open. ArcGIS Pro only runs one instance at a time, and an existing window will ignore the `/config:` flag entirely.

**Fix:** Close all open ArcGIS Pro windows, then launch again using the shortcut or command above.

### The start page looks like standard Pro (no seasonal background)

The configuration file may not be in the right folder. Verify:

```powershell
ls "$env:USERPROFILE\Documents\ArcGIS\AddIns\ArcGISPro\Configurations"
```

You should see `ArcPSLPro.proConfigX` listed. If the folder is empty or the file is missing, repeat Step 1.

---

## Using Standard ArcGIS Pro

The theme is completely opt-in. Launching ArcGIS Pro from the Start menu or your regular shortcut always opens standard Pro. The two shortcuts can coexist.

---

## Uninstalling

To remove the theme:

1. Delete `ArcPSLPro.proConfigX` from:
   ```
   %USERPROFILE%\Documents\ArcGIS\AddIns\ArcGISPro\Configurations
   ```
2. Delete the ArcPSL Pro desktop shortcut (if you created one).

Your projects, data, and ArcGIS Pro installation are not affected.

---

## Questions?

Contact your GIS administrator.
