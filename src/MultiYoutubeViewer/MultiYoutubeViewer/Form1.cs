using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MultiYoutubeViewer
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Dictionary<int, string>> _dic = new Dictionary<int, Dictionary<int, string>>();


        public Form1()
        {
            InitializeComponent();

            _dic.Clear();
            _dic = new Dictionary<int, Dictionary<int, string>>
            {
                {
                    0,
                    new Dictionary<int, string>
                    {
                        { 0, "https://youtu.be/URtVSE1lnVk" },
                        { 1, "https://youtu.be/bAEZtVOgFog" },
                        { 2, "https://youtu.be/ACykeL3jR-c" },
                        { 3, "https://youtu.be/QxEFHG1y8KU" },
                        { 4, "https://youtu.be/oc1mTmRM7Ig" },
                        { 5, "https://youtu.be/GLt0v8lm-_0" },
                        { 6, "https://youtu.be/A5u9UhScgrU" },
                        { 7, "https://youtu.be/RE3i7XytM2Q" },
                        { 8, "https://youtu.be/MKRVK9ZAcZs" }
                    }
                },

                {
                    1,
                    new Dictionary<int, string>
                    {
                        { 0, "https://youtu.be/jC6hlbEt2wI" },
                        { 1, "https://youtu.be/E1VU8TlcSJg" },
                        { 2, "https://youtu.be/gSUVNRStxLc" },
                        { 3, "https://youtu.be/0j4pKEUz_gw" },
                        { 4, "https://youtu.be/BQ0ZgSQREio" },
                        { 5, "https://youtu.be/iEskt_o2jPw" },
                        { 6, "https://youtu.be/vNH1cND8tSg" },
                        { 7, "https://youtu.be/P3BnCDkGwe4" },
                        { 8, "https://youtu.be/fEJ3LZK28D8" }
                    }
                }
            };

            comboBox1.SelectedIndex = 0;
            listBox1.SelectedIndex = 0;

        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void Display(int day, IEnumerable<int> selected)
        {

            var totalWidth = panel10.Width;
            var totalHeight = panel10.Height;

            var count = selected.Count();
            if (count == 0) { return; }

            panel10.Controls.Clear();

            if (count == 1)
            {
                var browser = new WebBrowser
                {
                    Width = totalWidth,
                    Height = totalHeight,
                    Url = new Uri(_dic[day][selected.Single()])
                };
                panel10.Controls.Add(browser);
            }
            else if (count <= 4)
            {
                var width = (totalWidth - 10) / 2;
                var height = (totalHeight - 10) / 2;

                for (int i = 0; i < count; i++)
                {
                    var browser = new WebBrowser
                    {
                        Width = width,
                        Height = height,
                        Url = new Uri(_dic[day][selected.ElementAt(i)])
                    };
                    panel10.Controls.Add(browser);
                    browser.Top = i < 2 ? 0 : height + 5;
                    browser.Left = i % 2 == 0 ? 0 : width + 5;
                }
            }
            else
            {
                var width = (totalWidth - 15) / 3;
                var height = (totalHeight - 15) / 3;

                for (int i = 0; i < count; i++)
                {
                    var browser = new WebBrowser
                    {
                        Width = width,
                        Height = height,
                        Url = new Uri(_dic[day][selected.ElementAt(i)])
                    };
                    panel10.Controls.Add(browser);
                    browser.Top = i < 3 ? 0 : (i < 6 ? height + 5 : (height + 5) * 2);
                    browser.Left = i % 3 == 0 ? 0 : (i % 3 == 1 ? width + 5 : (width + 5) * 2);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var idx = comboBox1.SelectedIndex;

            var selected = new List<int>();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.GetSelected(i))
                {
                    selected.Add(i);
                }
            }

            Display(idx, selected);

        }
    }
}
