using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string x1 = "b", x2 = "b", x3 = "b", x4 = "b",
        x5 = "b", x6 = "b", x7 = "b", x8 = "b", x9 = "b",x;
        public int i = 0;
        private async void tb9_TextChanged(object sender, EventArgs e)
        {
            x = "";
            x = tb9.Text;
            if (x == "x" || x == "o")
            {
                x9 = x;
                i++;
                label2.Text = await InvokeRequestResponseService(x1, x2, x3, x4, x5, x6, x7, x8, x9, i);
            }
            else label2.Text = "Neispravan unos";
            x = "";
        }

        private async void tb8_TextChanged(object sender, EventArgs e)
        {
            x = tb8.Text;
            if (x == "x" || x == "o")
            {
                x8 = x;
                i++;
                label2.Text = await InvokeRequestResponseService(x1, x2, x3, x4, x5, x6, x7, x8, x9, i);
            }
            else label2.Text = "Neispravan unos";
            x = "";
        }

        private async void tb7_TextChanged(object sender, EventArgs e)
        {
            x = tb7.Text;
            if (x == "x" || x == "o")
            {
                x7 = x;
                i++;
                label2.Text = await InvokeRequestResponseService(x1, x2, x3, x4, x5, x6, x7, x8, x9, i);
            }
            else label2.Text = "Neispravan unos";
            x = "";
        }

        private async void tb6_TextChanged(object sender, EventArgs e)
        {
            x = tb6.Text;
            if (x == "x" || x == "o")
            {
                x6 = x;
                i++;
                label2.Text = await InvokeRequestResponseService(x1, x2, x3, x4, x5, x6, x7, x8, x9, i);
            }
            else label2.Text = "Neispravan unos";
            x = "";
        }

        private async void tb5_TextChanged(object sender, EventArgs e)
        {
            x = tb5.Text;
            if (x == "x" || x == "o")
            {
                x5 = x;
                i++;
                label2.Text = await InvokeRequestResponseService(x1, x2, x3, x4, x5, x6, x7, x8, x9, i);
            }
            else label2.Text = "Neispravan unos";
            x = "";
        }

        private async void tb4_TextChanged(object sender, EventArgs e)
        {
            x = tb4.Text;
            if (x == "x" || x == "o")
            {
                x4 = x;
                i++;
                label2.Text = await InvokeRequestResponseService(x1, x2, x3, x4, x5, x6, x7, x8, x9, i);
            }
            else label2.Text = "Neispravan unos";
            x = "";
        }

        private async void tb3_TextChanged(object sender, EventArgs e)
        {
            x = tb3.Text;
            if (x == "x" || x == "o")
            {
                x3 = x;
                i++;
                label2.Text = await InvokeRequestResponseService(x1, x2, x3, x4, x5, x6, x7, x8, x9, i);
            }
            else label2.Text = "Neispravan unos";
            x = "";
        }

        private async void tb2_TextChanged(object sender, EventArgs e)
        {
            x = tb2.Text;
            if (x == "x" || x == "o")
            {
                x2 = x;
                i++;
                label2.Text = await InvokeRequestResponseService(x1, x2, x3, x4, x5, x6, x7, x8, x9, i);
            }
            else label2.Text = "Neispravan unos";
            x = "";
        }

        private async void tb1_TextChanged(object sender, EventArgs e)
        {
            x = tb1.Text;
            if (x == "x" || x == "o")
            {
                x1 = x;
                i++;
                label2.Text = await InvokeRequestResponseService(x1, x2, x3, x4, x5, x6, x7, x8, x9, i);
            }
            else label2.Text = "Neispravan unos";
            x = "";
        }
        static async Task<String> InvokeRequestResponseService(string x1, string x2, string x3, string x4, string x5, string x6, string x7, string x8, string x9, int i)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"x1", "x2", "x3", "x4", "x5", "x6", "x7", "x8", "x9"},
                                Values = new string[,] {  { x1, x2, x3, x4, x5, x6, x7, x8, x9 },   }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "P1Hclm6jAIr815tKzPiUVfEo+yqIEYpLEWL9RBJrvBXFVa20wnPa9BJvixu7TmGCSF6KemVS9It2SKREtgz7iA=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/1f9ae6cb4ff34747b3449cc6e536ba4d/services/52b40cd0cb634ed0875a15af9cf16e19/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JObject o = JObject.Parse(result);
                    
                    string label = "Vjerojatnost pobjede za igrača X: ";
                    double label2 = (double)o["Results"]["output1"]["value"]["Values"][0][10];
                    
                    if (i>4)
                    {   if((x1.Equals("x") && x2.Equals("x") && x3.Equals("x")) ||
                            (x1.Equals("x") && x5.Equals("x") && x9.Equals("x")) ||
                            (x1.Equals("x") && x4.Equals("x") && x7.Equals("x")) ||

                            (x2.Equals("x") && x5.Equals("x") && x8.Equals("x")) ||

                            (x3.Equals("x") && x5.Equals("x") && x7.Equals("x")) ||
                            (x3.Equals("x") && x6.Equals("x") && x9.Equals("x")) ||

                            (x4.Equals("x") && x5.Equals("x") && x6.Equals("x")) ||

                            (x7.Equals("x") && x8.Equals("x") && x9.Equals("x")))
                            {
                                MessageBox.Show("Igrač X je pobjedio s vjerojatnošću: \n"+ label2);
                                Application.Exit();
                            }
                        else if (((x1.Equals("o") && x2.Equals("o") && x3.Equals("o")) ||
                            (x1.Equals("o") && x5.Equals("o") && x9.Equals("o")) ||
                            (x1.Equals("o") && x4.Equals("o") && x7.Equals("o")) ||

                            (x2.Equals("o") && x5.Equals("o") && x8.Equals("o")) ||

                            (x3.Equals("o") && x5.Equals("o") && x7.Equals("o")) ||
                            (x3.Equals("o") && x6.Equals("o") && x9.Equals("o")) ||

                            (x4.Equals("o") && x5.Equals("o") && x6.Equals("o")) ||

                            (x7.Equals("o") && x8.Equals("o") && x9.Equals("o"))) || i==9)
                            {
                                MessageBox.Show("Igrač X nije pobjedio s vjerojatnošću: \n" + label2);
                                Application.Exit();
                            }
                    }
                    
                    return label +"\n" +label2;
                }
                else
                {
                    return "greška";
                    
                }
            }
        }

    }
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }
}
