using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;

namespace FormAppTest
{
    public class Model
    {
        private List<String[][]> boms;
        public Model()
        {

        }
        public void setBOMsFromPath(String[] paths)
        {
            Excel.Workbook MyBook = null;
            Excel.Application MyApp = null;
            Excel.Worksheet MySheet = null;

            boms = new List<String[][]>();
            foreach (String path in paths){
                MyApp = new Excel.Application(); //lets go new for every workbook
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(path);


                MySheet = (Excel.Worksheet) MyBook.Sheets[1];
                int lastUsedRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                int lastUsedColumn = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column; //find the extremes

                String[][] table = new String[lastUsedRow][];
                for (int index = 1; index <= lastUsedRow; index++){ //go by rows
                    Excel.Range c1 = MySheet.Cells[index, 1];
                    Excel.Range c2 = MySheet.Cells[index, lastUsedColumn];
                    System.Array MyValues = (System.Array)MySheet.get_Range(c1, c2).Cells.Value; //NOTE: cant use c1/c2 definition directly (object cast exception)

                    table[index-1] = new String[MyValues.Length];
                    for(int i=1;i<=MyValues.Length;i++){
                        if (MyValues.GetValue(1, i) == null){ //handle the null cell
                            table[index-1][i-1] = "";
                        }
                        else
                            table[index-1][i-1] = MyValues.GetValue(1, i).ToString();
                    }
                }
                MyBook.Close(SaveChanges: false); //close no save
                boms.Add(table);
            }
        }
        public String[][] getFirstBOM()
        {
            if(boms != null) 
                return boms.ElementAt(0);
            else 
                return null;
        }
        public void showAllBOMs()
        {
            if (boms != null){
                foreach(String[][] bom in boms){ //show all on the console
                    Console.WriteLine("=======================");
                    foreach(String[] row in bom){
                        foreach(String cell in row){
                            Console.Write(cell + " | ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
