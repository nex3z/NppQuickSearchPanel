using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NppPluginNET;

namespace NppQuickSearchPanel
{
    class Main
    {
        #region " Fields "
        internal const string PluginName = "NppQuickSearchPanel";
        static string iniFilePath = null;
        static frmQuickSearch frmMain = null;
        static int idMyDlg = -1;
        static Bitmap tbBmp = Properties.Resources.magnifier;
        static Bitmap tbBmp_tbTab = Properties.Resources.magnifier_bmp;
        static Icon tbIcon = null;
        public const string PluginVersion = "0.8.5";
        #endregion

        #region " StartUp/CleanUp "
        internal static void CommandMenuInit()
        {
            StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
            iniFilePath = sbIniFilePath.ToString();
            if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
            LoadConfig(iniFilePath);

            PluginBase.SetCommand(0, "Show QuickSearchPanel", ShowMain); idMyDlg = 0;
            PluginBase.SetCommand(1, "Help && About", ShowHelp, new ShortcutKey(false, false, false, Keys.None));
        }
        internal static void SetToolBarIcon()
        {
            toolbarIcons tbIcons = new toolbarIcons();
            tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }
        internal static void PluginCleanUp()
        {
            if (frmMain.Visible)
                Settings.Configs.showOnStartup = true;
            else
                Settings.Configs.showOnStartup = false;

            if (frmMain != null)
                frmMain.Close();

            SaveConfig(iniFilePath);
        }
        internal static void LoadConfig(string iniFilePath)
        {           
            string iniFileName = Path.Combine(iniFilePath, PluginName + ".ini");
            Settings.ConfigDir = iniFilePath;
            Settings.LoadConfigs();
        }
        internal static void SaveConfig(string iniFilePath)
        {
            Settings.SaveConfigs();
        }
        #endregion

        #region " Menu functions "
        internal static void ShowHelp()
        {
            MessageBox.Show("NppQuickSearchPanel v" + PluginVersion + "\nCreated by Tianxing Li ( litianxing9@gmail.com )");
        }
        internal static void ShowMain()
        {
            if (frmMain == null)
            {
                frmMain = new frmQuickSearch();

                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(tbBmp_tbTab, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmMain.Handle;
                _nppTbData.pszName = "Quick Search";
                _nppTbData.dlgID = idMyDlg;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETMENUITEMCHECK, PluginBase._funcItems.Items[idMyDlg]._cmdID, 1);
            }
            else
            {
                if (frmMain.Visible)
                {
                    Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DMMHIDE, 0, frmMain.Handle);
                    Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETMENUITEMCHECK, PluginBase._funcItems.Items[idMyDlg]._cmdID, 0);
                }
                else
                {
                    Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DMMSHOW, 0, frmMain.Handle);
                    Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_SETMENUITEMCHECK, PluginBase._funcItems.Items[idMyDlg]._cmdID, 1);
                }
            }
        }
        #endregion
    }
}