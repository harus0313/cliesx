using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Svg;

namespace cliesx
{
    public partial class cliesx : Form
    {
        public cliesx()
        {
            InitializeComponent();
        }

        public class CmdInfo
        {
            public string cmdStr;
            public string cmdDescription;
        }

        List<CmdInfo> cmds = new List<CmdInfo>();

        // カラーパレットを表示して RGBコードを返す関数
        //https://learn.microsoft.com/ja-jp/dotnet/desktop/winforms/controls/how-to-show-a-color-palette-with-the-colordialog-component?view=netframeworkdesktop-4.8
        bool getColorCode(out Color colorCode)
        {
            colorCode = Color.White;
            //todo : モダンなUIに変更する
            //todo : モダンなカラーサンプルプリセットを用意する

            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorCode = colorDialog1.Color;
                return true;
            }else
            {
                return false;
            }
            
        }

        void parseCmd(string cmd)
        {
            bool retStatus = false;
            Color colorCode;
            string fullName = "";
            string fileName = "";
            string folderPath = "";

            switch(cmd)
            {
                //コマンド体系

                case "FontColor":
                    if( getColorCode(out colorCode))
                    {
                        ThisAddIn.ChangeFontColor(colorCode);
                    }
                    break;
                
                // CellColor

                // 読み取り専用に変更する
                case "ReadOnly":
                    ThisAddIn.ChangeFileAccess(Microsoft.Office.Interop.Excel.XlFileAccess.xlReadOnly);
                    break;

                // 読み取り専用を解除する
                case "ReadWrite":
                    ThisAddIn.ChangeFileAccess(Microsoft.Office.Interop.Excel.XlFileAccess.xlReadWrite);
                    break;


                //GroupRowグループ化する（行）
                case "GroupRowOn":
                    ThisAddIn.GroupRow(true);
                    break;

                //UnGroupRowグループ化を解除する（行）
                case "GroupRowOff":
                    ThisAddIn.GroupRow(false);
                    break;

                //GrouColグループ化する（列）
                case "GroupColOn":
                    ThisAddIn.GroupColumn(true);
                    break;

                //UnGroupColグループ化を解除する（列）
                case "UnGroupColOff":
                    ThisAddIn.GroupColumn(false);
                    break;

                //アウトラインレベルを変更する

                //GetFileNameファイル名をコピーする
                case "GetFileName":
                    fullName = ThisAddIn.GetFullName();
                    fileName = System.IO.Path.GetFileName(fullName);
                    Clipboard.SetText(fileName);
                    break;
                //GetFilePathフルパスをコピーする
                case "GetFilePath":
                    fullName = ThisAddIn.GetFullName();
                    Clipboard.SetText(fullName);
                    break;

                case "GetFoldePath":
                    fullName = ThisAddIn.GetFullName();
                    folderPath = System.IO.Path.GetDirectoryName(fullName);
                    Clipboard.SetText(folderPath);
                    break;

                //GetSheetName アクティブシート名をコピーする
                case "GetSheetName":
                    string sheetName = ThisAddIn.GetSheetName();
                    Clipboard.SetText(sheetName);
                    break;

                //AddSheet シートを追加する
                case "AddSheet":
                    ThisAddIn.AddSheet();
                    break;
                //DeleteSheet シートを削除する
                case "DeleteSheet":
                    ThisAddIn.DeleteSheet();
                    break;
                //CopySheet シートを複製する
                case "CopySheet":
                    ThisAddIn.CopySheet();
                    break;


                //AddImage 画像を挿入する
                case "AddIcon":
                    Form webviewForm = new WebViewForm();
                    webviewForm.Show();
                    break;

                //AddTemplateSheet テンプレートからシートを追加する
                //SaveAsTemplateSheetテンプレートシートとして保存する
                //EditTemplateSheetテンプレートシートを編集する
                //SheetColor シートタブの色を変更する

                //ExecuteSQLinODBC ODBC接続からSQLを実行する
                //ExecuteSQLinCSV CSVファイルからSQLを実行する 
                //ExecuteSQLinTSV TSVファイルからSQLを実行する

                // CellLeftセルを左寄せにする
                case "CellLeft":
                    ThisAddIn.CellHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft);
                    break;
                // CellCenterセルを中央寄せにする
                case "CellCenter":
                    ThisAddIn.CellHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter);
                    break;
                // CellRightセルを右寄せにする
                case "CellRight":
                    ThisAddIn.CellHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight); 
                    break;
                // CellCenterSelection選択セルで中央寄せする
                case "CellCenterSelection":
                    ThisAddIn.CellHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenterAcrossSelection); 
                    break;
                // CelllTopセルを上寄せにする
                case "CellTop":
                    ThisAddIn.CellVerticalAlignment(Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop);
                    break;
                // CellMiddleセルを上下中央にする
                case "CellMiddle":
                    ThisAddIn.CellVerticalAlignment(Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter);
                    break;
                // CellBottomセルを下寄せにする
                case "CellBottom":
                    ThisAddIn.CellVerticalAlignment(Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom);
                    break;

                // MergeCellセルをマージする
                case "MergeCellOn":
                    ThisAddIn.MergeActiveCell();
                    break;
                case "MergeCellOff":
                    ThisAddIn.UnMergeActiveCell();
                    break;

                //DisplayGridLinesOff 枠線（目盛線）を非表示にする
                case "DisplayGridLinesOff":
                    ThisAddIn.DisplayGridLines(false); break;
                //DisplayGridLinesOn 枠線（目盛線）を表示する
                case "DisplayGridLinesOn":
                    ThisAddIn.DisplayGridLines(true);
                    break;

                case "DisplayFomulasBarOff":
                    ThisAddIn.DisplayFomulasBar(false); break;
                case "DisplayFomulasBarOn":
                    ThisAddIn.DisplayFomulasBar(true); break;

                case "DisplayClipboardOff":
                    ThisAddIn.DisplayClipboard(false); break;
                case "DisplayClipboardOn":
                    ThisAddIn.DisplayClipboard(true); break;

                case "DisplayFullScreenOff":
                    ThisAddIn.DisplayFullScreen(false); break;
                case "DisplayFullScreenOn":
                    ThisAddIn.DisplayFullScreen(true); break;
                case "ShowDialogSort":
                    ThisAddIn.ShowDialog(Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogSort);
                    break;
                case "ShowDialogFont":
                    ThisAddIn.ShowDialog(Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogFont); break;

                case "ShowDialogPrintPreview":
                    ThisAddIn.ShowDialog(Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogPrintPreview);
                    break;

                case "ShowDialogFileSharing":
                    ThisAddIn.ShowDialog(Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogFileSharing);
                    break;

                case "ShowDialogProtectSharing":
                    ThisAddIn.ShowDialog(Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogProtectSharing);
                    break;

                //pdf形式に変換する
                //xlsm形式に変換する

                    // VBAコードを自動生成する
                    // VBEを表示する
                    // VBAコードスニペットを保存する
                    // VBAコードスニペットを表示する

                    // 各シートA1セルに移動して保存する


                    // Outlookメールを新規作成する
                    // Outlookメールを新規作成する（アクティブなブックを添付する）


                    // 意味検索
                    // 英和検索
                    // 和英検索

                    // 新しいExcelインスタンスを起動する




            }
        }

        void AddCmdInfo()
        {
            CmdInfo cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "AddSheet";
            cmdInfo.cmdDescription = "現在のブックに新しいシートを追加します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "CellBottom";
            cmdInfo.cmdDescription = "セルの文字の配置を下詰めにします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "CellCenter";
            cmdInfo.cmdDescription = "セルの文字の配置を中央揃えにします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "CellCenterSelection";
            cmdInfo.cmdDescription = "セルの文字の配置を選択範囲内で中央揃えにします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "CellLeft";
            cmdInfo.cmdDescription = "セルの文字の配置を左詰めにします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "CellMiddle";
            cmdInfo.cmdDescription = "セルの文字の配置を上下中央にします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "CellRight";
            cmdInfo.cmdDescription = "セルの文字の配置を右詰めにします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "CellTop";
            cmdInfo.cmdDescription = "セルの文字の配置を上詰めにします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "CopySheet";
            cmdInfo.cmdDescription = "現在のシートを複製します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "DeleteSheet";
            cmdInfo.cmdDescription = "現在のシートを削除します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "DisplayClipboardOff";
            cmdInfo.cmdDescription = "クリップボードパネルを非表示にします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "DisplayClipboardOn";
            cmdInfo.cmdDescription = "クリップボードパネルを表示します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "DisplayFomulasBarOff";
            cmdInfo.cmdDescription = "数式バーを非表示にします";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "DisplayFomulasBarOn";
            cmdInfo.cmdDescription = "数式バーを表示します";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "DisplayFullScreenOff";
            cmdInfo.cmdDescription = "フルスクリーンモードをオフにします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "DisplayFullScreenOn";
            cmdInfo.cmdDescription = "フルスクリーンモードをオンにします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "DisplayGridLinesOn";
            cmdInfo.cmdDescription = "メモリ線を表示します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "DisplayGridLinesOff";
            cmdInfo.cmdDescription = "メモリ線を非表示にします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "FontColor";
            cmdInfo.cmdDescription = "セル文字色を変更します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "GetFileName";
            cmdInfo.cmdDescription = "ファイル名をクリップボードにコピーします";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "GetFilePath";
            cmdInfo.cmdDescription = "ファイルフルパスをクリップボードにコピーします";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "GetFoldePath";
            cmdInfo.cmdDescription = "フォルダパスをクリップボードにコピーします";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "GetSheetName";
            cmdInfo.cmdDescription = "シート名をクリップボードにコピーします";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "GroupColOn";
            cmdInfo.cmdDescription = "列をグループ化します";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "GroupColOff";
            cmdInfo.cmdDescription = "列のグループ化を解除します";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "GroupRowOn";
            cmdInfo.cmdDescription = "行をグループ化します";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "GroupRowOff";
            cmdInfo.cmdDescription = "行のグループ化を解除します";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "MergeCellOff";
            cmdInfo.cmdDescription = "選択範囲のセル結合を解除します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "MergeCellOn";
            cmdInfo.cmdDescription = "選択範囲のセルを結合します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "ReadOnly";
            cmdInfo.cmdDescription = "ブックを読み取り専用にします。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "ReadWrite";
            cmdInfo.cmdDescription = "ブックの読み取り専用を解除します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "AddIcon";
            cmdInfo.cmdDescription = "アイコン一覧を表示します。コピー＆ペーストでExcelシートに貼り付けできます。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "ShowDialogSort";
            cmdInfo.cmdDescription = "並び替えダイアログを表示します。";
            cmds.Add(cmdInfo);

            cmdInfo = new CmdInfo();
            cmdInfo.cmdStr = "ShowDialogFont";
            cmdInfo.cmdDescription = "フォント設定ダイアログを表示します。";
            cmds.Add(cmdInfo);



        }

        private void cliesx_Load(object sender, EventArgs e)
        {
            AddCmdInfo();

            foreach (var item in cmds)
            {
                CmdComboBox.Items.Add(item.cmdStr + " - " + item.cmdDescription);
            }


        }
         
        private void CmdComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                parseCmd(CmdComboBox.Text.Split('-')[0].Trim());
            }

        }

        private void CmdComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var item in cmds)
            {
                if (item.cmdStr.ToLower() == CmdComboBox.Text.ToLower())
                {
                    cmdDescLabel.Text = item.cmdDescription;
                    return;
                }
            }

            cmdDescLabel.Text = "コマンドを選択してください";
        }

        private void convertSVGtoPNG()
        {
            var svgDocument = Svg.SvgDocument.Open("C:\\Users\\Administrator\\OneDrive\\source\\repos\\cliesx\\svg\\500px.svg");
            var bitmap = svgDocument.Draw();
            bitmap.Save("C:\\Users\\Administrator\\OneDrive\\source\\repos\\cliesx\\png\\500px.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        //TODO: 検索機能を追加する。日本語文で機能を検索できるようにする。
        //TODO: オープンソースアイコンブラウザを開発する。png形式でコピーできるようにする。
    }
}
