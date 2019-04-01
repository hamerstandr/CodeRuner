using Antlr4.Runtime;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.CSharp;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Xml;
using UtfUnknown;

namespace CodeRuner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Word
        {
            public string Text;
            public Color Color;
        }
        //List<Word> ListWords = new List<Word>();
        
        public MainWindow()
        {//_localctx.Csharp+=(_localctx.a!=null?_localctx.a.Text:null)+ (_localctx.aa != null ? _localctx.aa.Csharp : null)+ "<"+ _localctx.b.Csharp+";"+(_localctx.a!=null?_localctx.a.Text:null)+(_localctx.aa != null ? _localctx.aa.Csharp : null) + "++)"+Environment.NewLine;
            InitializeComponent();
            //ListWords.Add(new Word() { Text = "module", Color = Colors.Purple });
            //ListWords.Add(new Word() { Text = "While", Color = Colors.DarkBlue });
            //ListWords.Add(new Word() { Text = "If", Color = Colors.DarkBlue });
            //ListWords.Add(new Word() { Text = "Begin", Color = Colors.DarkGreen });
            //ListWords.Add(new Word() { Text = "End", Color = Colors.DarkGreen });

            //ListWords.Add(new Word() { Text = "Else", Color = Colors.DarkBlue });
            //ListWords.Add(new Word() { Text = "Then", Color = Colors.DarkBlue });
            //ListWords.Add(new Word() { Text = "Int", Color = Colors.Purple });
            //ListWords.Add(new Word() { Text = "String", Color = Colors.Purple });
            //ListWords.Add(new Word() { Text = "Bool", Color = Colors.Purple });
            Init();
            nevise.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".codN");
            CshapTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".codC");
        }
        public void Init()
        {
            var hlm = HighlightingManager.Instance;

            var assemblyPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (string.IsNullOrEmpty(assemblyPath)) return;

            var syntaxPath = Path.Combine(assemblyPath, "Syntax");
            if (!Directory.Exists(syntaxPath)) return;

            foreach (var file in Directory.EnumerateFiles(syntaxPath, "*.xshd"))
            {
                var ext = Path.GetFileNameWithoutExtension(file);
                using (Stream s = File.OpenRead(Path.GetFullPath(file)))
                using (var reader = new XmlTextReader(s))
                {
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    var highlightingDefinition = HighlightingLoader.Load(xshd, hlm);
                    if (xshd.Extensions.Count > 0)
                        hlm.RegisterHighlighting(ext, xshd.Extensions.ToArray(), highlightingDefinition);
                }
            }
        }
        private void LoadFileAsync(string path)
        {
            try {
                Task.Run(() =>
                            {
                                const int maxLength = 50 * 1024 * 1024;
                                var buffer = new MemoryStream();
                                bool tooLong;
                                MyBusyIndicator.IsBusy = true;
                                using (var s = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                {
                                    tooLong = s.Length > maxLength;
                                    while (s.Position < s.Length && buffer.Length < maxLength)
                                    {

                                        var lb = new byte[8192];
                                        var count = s.Read(lb, 0, lb.Length);
                                        buffer.Write(lb, 0, count);
                                    }
                                }


                                //if (tooLong)
                                //    nevise.Title += " (0 ~ 50MB)";

                                var bufferCopy = buffer.ToArray();
                                buffer.Dispose();

                                var encoding = CharsetDetector.DetectFromBytes(bufferCopy).Detected?.Encoding ??
                                               Encoding.Default;

                                var doc = new TextDocument(encoding.GetString(bufferCopy));
                                doc.SetOwnerThread(Dispatcher.Thread);

                                Dispatcher.BeginInvoke(new Action(() =>
                                {
                                    nevise.Encoding = encoding;
                                    nevise.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(System.IO.Path.GetExtension(path));
                                    nevise.Document = doc;

                                    MyBusyIndicator.IsBusy = false;
                                }), DispatcherPriority.Render);
                            });
            } catch { MyBusyIndicator.IsBusy = false; }
            
        }
        /// <summary>
        /// This method highlights a word with a given color in a WPF RichTextBox
        /// </summary>
        /// <param name="richTextBox">RichTextBox Control</param>
        /// <param name="word">The word which you need to highlighted</param>
        /// <param name="color">The color with which you highlight</param>
        private void HighlightWordInRichTextBox(RichTextBox myRtb, String word, SolidColorBrush color)
        {


            ////Current word at the pointer
            //TextRange tr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            //tr.Text = word;
            //tr.ApplyPropertyValue(TextElement.ForegroundProperty, color);
        }
        string GetneviseText()
        {

            return this.nevise.Document.Text;//new TextRange(this.nevise.Document.ContentStart, nevise.Document.ContentEnd).Text;
        }
        string GetCshapText()
        {
            return this.CshapTextBox.Document.Text;
            //return new TextRange(this.CshapTextBox.Document.ContentStart, CshapTextBox.Document.ContentEnd).Text;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorList1.Items.Clear();
            //string File = "Simple";

            AntlrInputStream input = new AntlrInputStream(GetneviseText());
            input.name = "Simple";
            var lexer = new sampleLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            var parser = new sampleParser(tokens);



            var exp = parser.prog();
            for (int i = 0; i < parser.khata_parser.Count(); i++)
            {
                if (parser.khata_parser[i] != null)
                {
                    ErrorList1.Items.Add(new ListViewItem() { Content = parser.khata_parser[i],Foreground=Brushes.DarkRed });
                }
            }
            if (parser.khata_parser.Count() == 0)
                DebugAndRun(parser.cod + "}");
            parser.khata_pakon();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DebugAndRun(GetCshapText());
        }
        private void DebugAndRun(string Code )
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
#pragma warning disable CS0618 // Type or member is obsolete
            ICodeCompiler icc = codeProvider.CreateCompiler();
#pragma warning restore CS0618 // Type or member is obsolete
            string Output = "Out.exe";
            ErrorText.Text = "";
            CompilerParameters parameters = new CompilerParameters();
            CompilerResults results;
            // Make sure we generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;
            results = icc.CompileAssemblyFromSource(parameters, Code);

            if (results.Errors.HasErrors)
            {
                // There were compiler errors
                ErrorText.Foreground = Brushes.DarkRed;

                foreach (CompilerError item in results.Errors)
                {
                    ErrorText.Text = (ErrorText.Text + ("Line number "
                                + (item.Line + (", Error Number: "
                                + (item.ErrorNumber + (", \'"
                                + (item.ErrorText + (";"
                                + (Environment.NewLine + Environment.NewLine)))))))));
                }

                //for (int k = 0; k < results.Errors.Count; k++)
                //{
                //    //if (results.Errors[k]==null) break;
                //    //string s = results.Errors;
                //    ErrorText.Text = (ErrorText.Text + ("Line number "
                //                + (results.Errors[k].Line + (", Error Number: "
                //                + (results.Errors[k].ErrorNumber + (", \'"
                //                + (results.Errors[k].ErrorText + (";"
                //                + (Environment.NewLine + Environment.NewLine)))))))));
                //}

            }
            else
            {
                // Successful Compile
                ErrorText.Foreground = Brushes.DarkBlue;
                ErrorText.Text = "Success!";
                var x = MessageBox.Show("Debugin was Successfully.Are you want RUN now?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (x == MessageBoxResult.Yes)
                {
                    try { System.Diagnostics.Process.Start(Output); } catch { }
                    
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            ErrorList1.Items.Clear();
            AntlrInputStream input = new AntlrInputStream(GetneviseText());

            var lexer = new sampleLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            var parser = new sampleParser(tokens);
            //CshapTextBox.Document.Blocks.Add(new Paragraph(new Run( parser.cod)));
            var exp = parser.prog();
            CshapTextBox.Document.Text="";
            CshapTextBox.Document.Text=parser.cod + Environment.NewLine + "}";

            for (int i = 0; i < parser.khata_parser.Count(); i++)
            {
                //Console.BackgroundColor =ConsoleColor.Red;
                ErrorList1.Items.Add(parser.khata_parser[i]);
            }
            parser.khata_pakon();
        }

        private void SaveExe(object sender, RoutedEventArgs e)
        {
            //"Out.exe"
            SaveFileDialog S = new SaveFileDialog();
            S.Filter = "*.exe|*.exe";
            S.ShowDialog();
            try
            {
                System.IO.File.Copy("Out.exe", S.FileName);
            } catch { }

        }

        private void nevise_KeyUp(object sender, KeyEventArgs e)
        {
            //HighlightWordInRichTextBox(nevise, "write", new SolidColorBrush(Colors.DarkRed));
            
        }

        private void ButtonFile_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.ContextMenu.IsOpen = true;
        }


        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog O = new OpenFileDialog();
            O.Filter = "*.codN|*.codN|*.*|*.*";
            O.ShowDialog();
            if(O.CheckFileExists) try
                {
                    this.nevise.Load(O.FileName);
                    this.nevise.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(O.FileName));
                    //LoadXamlPackage(nevise,O.FileName);
                }
                catch { }
        }
        private void Openc_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog O = new OpenFileDialog();
            O.Filter = "*.codC|*.codC|*.*|*.*";
            O.ShowDialog();
            if (O.CheckFileExists) try
                {
                    this.CshapTextBox.Load(O.FileName);
                    this.CshapTextBox.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(O.FileName));
                    //LoadXamlPackage(CshapTextBox,O.FileName);
                }
                catch { }
        }
        // Load XAML into RichTextBox from a file specified by _fileName
        void LoadXamlPackage(RichTextBox richTextBox, string _fileName)
        {
            TextRange range;
            FileStream fStream;
            if (File.Exists(_fileName))
            {
                range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                fStream = new FileStream(_fileName, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.XamlPackage);
                fStream.Close();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog S = new SaveFileDialog();
            S.Filter = "*.codN|*.codN|*.*|*.*";
            S.ShowDialog();
            try
            {
                this.nevise.Save(S.FileName);
                //SaveXamlPackage(nevise,S.FileName);
            }
            catch { }
        }
        private void Savec_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog S = new SaveFileDialog();
            S.Filter = "*.codC|*.codC|*.*|*.*";
            S.ShowDialog();
            try
            {
                this.CshapTextBox.Save(S.FileName);
                //SaveXamlPackage(CshapTextBox, S.FileName);
            }
            catch { }
        }
        // Save XAML in RichTextBox to a file specified by _fileName
        void SaveXamlPackage(RichTextBox richTextBox, string _fileName)
        {
            TextRange range;
            FileStream fStream;
            range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            fStream = new FileStream(_fileName, FileMode.Create);
            range.Save(fStream, DataFormats.XamlPackage);
            fStream.Close();
        }
        public string LongText { get; set; }

        public int Lines
        {
            get { return (int)GetValue(LinesProperty); }
            set { SetValue(LinesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Lines.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LinesProperty =
            DependencyProperty.Register("Lines", typeof(int), typeof(MainWindow), new UIPropertyMetadata(-1));

        private void ErrorText_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
