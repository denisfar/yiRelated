using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yellowRelatedProducts
{
    static class Program
    {

        public class idList
        {

            private List<String> list;

            public idList()
            {
                list = new List<string>();
            }

           
            public int addId(string id)
            {
                list.Add(id.ToString());
                return 0;
            }


            public List<string> getList()
            {
                return list;
            }

            public void clear()
            {
                list.Clear();
            }

            public void deleteItem(int id)
            {
                List<string> tempList = new List<string>();
                for (int i = 0; i < list.Count; i++)
                {
                    if(i!=id)
                        tempList.Add(list[i]);
                }
                list.Clear();
                foreach(string item in tempList)
                {
                    list.Add(item);
                }

            }


        }

        public static idList list;
        static Form1 form1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            list = new idList();

            Application.Run(form1);

        }

        static public void AddToList(string id)
        {
            list.addId(id);
            form1.render(list.getList());
        }

        static public void clearList()
        {
            list.clear();
        }


        static public void deleteItem(int id)
        {
            list.deleteItem(id);

        }

    }
}
