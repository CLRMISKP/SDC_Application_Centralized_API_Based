using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

/* 
  USAGE
 DataGridViewHelper dgh = new DataGridViewHelper(GridViewKhewatMalikaan);
            dgh.ExportAllRowsToCSV();
 */
public class DataGridViewHelper
{
    public static Font font = null;
    private DataGridView dataGridView;
    private DataGridViewSelectionMode originalSelectionMode;

    public DataGridViewHelper(DataGridView dgv)
    {
        dataGridView = dgv;
        originalSelectionMode = dataGridView.SelectionMode;


        // Create a ContextMenuStrip
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

        // Create a ToolStripMenuItem "Export to HTML" with an anonymous function handler
        ToolStripMenuItem exportToHtmlItem = new ToolStripMenuItem("Export to HTML");
        exportToHtmlItem.Click += (s, eventArgs) =>
        {
            // Handle the "Export to HTML" click event here
            GenerateHtmlTable();
        };

        // Add the "Export to HTML" item to the context menu
        contextMenuStrip.Items.Add(exportToHtmlItem);

        // Set the context menu for the DataGridView
        dataGridView.ContextMenuStrip = contextMenuStrip;
    }


    public static void LoadFontFromResource(Control control)
    {
        if(DataGridViewHelper.font==null){
                // Load the font data from your resources
                byte[] fontData = SDC_Application.Resource1.alvi_Nastaleeq_Lahori_shipped;

                if (fontData == null)
                {
                   // throw new Exception("Font resource not found.");
                }

                // Create a private font collection
                using (PrivateFontCollection fontCollection = new PrivateFontCollection())
                {
                    // Pin the font data in memory
                    IntPtr fontDataPtr = Marshal.AllocCoTaskMem(fontData.Length);
                    Marshal.Copy(fontData, 0, fontDataPtr, fontData.Length);

                    // Add the font to the collection
                    fontCollection.AddMemoryFont(fontDataPtr, fontData.Length);

                    // Free the pinned memory
                    Marshal.FreeCoTaskMem(fontDataPtr);

                    DataGridViewHelper.font= new Font(fontCollection.Families[0], 12);
                }
        }

                   // if (control.GetType() != typeof(CheckBox) && control.Font != null)
                  if ( control.Font != null)
                    {
                        if (control.Name == "label1") {
                            int i = 0; 
                            i++;
                        }
                        // Create a new font with the loaded font family and the existing font size and style
                        Font newFont = new Font(DataGridViewHelper.font.FontFamily, control.Font.Size, control.Font.Style);
  
                        // Apply the new font to the control
                       control.Font = newFont;
                    }
                    else
                    {
                        // The control doesn't have a font property, so you can't apply the font.
                        //throw new Exception("Control does not have a font property.");
                    }
    }

    // Recursive function to find DataGridView controls within containers
    private static void  FindDataGridViews(Control parentControl)
    {
        if (parentControl is DataGridView)
        {
            DataGridView dg = (DataGridView)parentControl;
            new DataGridViewHelper(dg);
            return;
        }

        foreach (Control control in parentControl.Controls)
        {
            if (control is DataGridView)
            {
                DataGridView dg = (DataGridView)control;
                new DataGridViewHelper(dg);
            }
            else
            {
                // Recursively search for DataGridView controls in child controls
                FindDataGridViews(control);
            }
        }
    }

    // Recursive function to find DataGridView controls within containers
    // Recursive function to set the font for controls that have a Font property
    private static void SetFont(Control parentControl)
    {
        DataGridViewHelper.LoadFontFromResource(parentControl);

        foreach (Control control in parentControl.Controls)
        {
            
            /*if (control.Font != null)
            {
                DataGridViewHelper.LoadFontFromResource(control);
                control.Font = font;
            }*/
            SetFont(control);
        }
    }



    public static void addHelpterToAllFormGridViews(Form frm){
        // Call the recursive function to find DataGridView controls


        foreach (Control control in frm.Controls)
        {
            FindDataGridViews(control);
        }

        foreach (Control control in frm.Controls)
        {
           // SetFont(control);
        }
    }


    public  void GenerateHtmlTable()
    {
        try
        {
            // Create a unique HTML file name based on the current timestamp
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string htmlFileName = "CSVTable_"+timeStamp+".html";

            string htmlContent = GenerateDataGridHtml();

            // Save the HTML content to a file
            string tempFolderPath = Path.GetTempPath();
            string htmlFilePath = Path.Combine(tempFolderPath, htmlFileName);

            using (TextWriter writer = new StreamWriter(htmlFilePath, false, Encoding.UTF8))
            {
                writer.Write(htmlContent.ToString());
            }

            // Open the HTML file with the default system application (usually a web browser)
            System.Diagnostics.Process.Start(htmlFilePath);
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur during file generation or opening
            Console.WriteLine("Error: "+ex.Message+"");
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public string ConvertDataGridViewToJSArray(DataGridView dataGridView1)
    {
        StringBuilder sb = new StringBuilder();

        // Add JavaScript array initialization
        sb.Append("const dataGrid_NO_SEL = [\n");

        // Headers
        sb.Append("[");
        foreach (DataGridViewColumn column in dataGridView1.Columns)
        {
            if (column.Visible)
            {
                sb.Append("\"" + column.HeaderText + "\",");
            }
        }
        sb.Length--;  // remove the last comma
        sb.Append("],\n");

        // Rows
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            sb.Append("[");
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.OwningColumn.Visible)
                {
                    string cellValue = cell.Value == null ? "" : cell.Value.ToString()
                        .Replace(",", "'")
                        .Replace("\"", "'")
                        .Replace("\r\n", "\\n")
                        .Replace("\n\r", "\\n")
                        .Replace("\r", "\\n")
                        .Replace("\n", "\\n");
                    sb.Append("\"" + cellValue + "\",");
                }
            }
            sb.Length--;  // remove the last comma
            sb.Append("],\n");
        }
        sb.Length -= 2;  // remove the last comma and newline
        sb.Append("\n];\n");  // Close the JavaScript array definition

        return sb.ToString();
    }


public string GenerateDataGridHtml()
{
    string cSharpHtml = @"

<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>DataGrid Table</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        th, td {
            padding: 8px 12px;
            border: 1px solid black;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>

<div id='tableContainer'></div>
<div id='totalsContainer'></div>

<script>
" + ConvertDataGridViewToJSArray(dataGridView) + @"

	
let lastSortedColumnName = '';
let lastSortedDirection = '';  // either '↑' or '↓'

dataGrid = addSelectColumn(dataGrid_NO_SEL);
console.log(dataGrid);

document.getElementById('tableContainer').innerHTML = generateHTMLTable(dataGrid);
document.getElementById('totalsContainer').innerHTML = generateTotalsHTML(dataGrid);


function sortDataGrid(columnIndex, sortInt) {
    const compareFunction = (a, b) => {
        if (a[columnIndex] < b[columnIndex]) return sortInt;
        if (a[columnIndex] > b[columnIndex]) return -sortInt;
        return 0;
    };

    // Exclude the header row, sort the rest
    const header = dataGrid[0];
    const sortedRows = dataGrid.slice(1).sort(compareFunction);

    dataGrid = [header, ...sortedRows];   
}



function toggleArrow(event) {
    const thElement = event.target;
    const clickedHeader = thElement.innerText;
    
    // Remove arrows from clickedHeader, if they exist
    const cleanedHeader = clickedHeader.replace('↑', '').replace('↓', '');

    // Determine the column index
    const columnIndex = dataGrid[0].findIndex(header => header === cleanedHeader);

    // Determine sort direction
    const sortInt = thElement.innerHTML.endsWith('↑') ? -1 : 1;  // Toggle the sorting direction

    lastSortedColumnName = cleanedHeader;
    lastSortedDirection = sortInt === 1 ? '↑' : '↓';

    // Sort the dataGrid based on the clicked header
    sortDataGrid(columnIndex, sortInt);

    // Re-render the table with the sorted dataGrid
    document.querySelector('table').outerHTML = generateHTMLTable(dataGrid);
}




function headerClicked(event) {
    const headerText = event.target.innerText;
    //alert(`You clicked the header: ${headerText}`);
    toggleArrow(event);  // Add this line
}

function selectClicked() {
    let anySelected = dataGrid.some(row => row[row.length - 1] === 'true');

    if (anySelected) {
        for (let i = 1; i < dataGrid.length; i++) {
            dataGrid[i][dataGrid[i].length - 1] = 'false';
        }
    } else {
        for (let i = 1; i < dataGrid.length; i++) {
            dataGrid[i][dataGrid[i].length - 1] = 'true';
        }
    }

    // Re-render the table
    document.getElementById('tableContainer').innerHTML = generateHTMLTable(dataGrid);
}


function checkboxClicked(event, rowIndex) {
    const isChecked = event.target.checked;
    
    // Update the corresponding value in the dataGrid
    dataGrid[rowIndex][dataGrid[rowIndex].length - 1] = isChecked ? 'true' : 'false';

    // Update the totals
    document.getElementById('totalsContainer').innerHTML = generateTotalsHTML(dataGrid);
}

function sumKanalMarlaFeet(valueStr, currentSumStr) {
    const KANAL_TO_FEET = 5445;
    const MARLA_TO_FEET = 272.25;

    const convertToFeet = (kanal, marla, feet) => {
        return (kanal * KANAL_TO_FEET) + (marla * MARLA_TO_FEET) + parseFloat(feet);
    };

    const [valueKanal, valueMarla, valueFeet] = valueStr.split('-').map(Number);
    const [sumKanal, sumMarla, sumFeet] = currentSumStr.split('-').map(Number);

    const totalValueFeet = convertToFeet(valueKanal, valueMarla, valueFeet);
    const totalSumFeet = convertToFeet(sumKanal, sumMarla, sumFeet);

    const totalFeet = totalValueFeet + totalSumFeet;

    const resultantKanal = Math.floor(totalFeet / KANAL_TO_FEET);
    const resultantFeetWithoutKanal = totalFeet % KANAL_TO_FEET;
    const resultantMarla = Math.floor(resultantFeetWithoutKanal / MARLA_TO_FEET);
    const resultantFeet = resultantFeetWithoutKanal % MARLA_TO_FEET;

    return `${resultantKanal}-${resultantMarla}-${resultantFeet.toFixed(2)}`;
}



function generateTotalsHTML(dataGrid) {
    // Fetch column widths from the 'tableContainer' table
    let table = document.querySelector('#tableContainer table');
    let columnWidths = [];
    if (table) {
        let headerCells = table.rows[0].cells;
        for (let cell of headerCells) {
            columnWidths.push(cell.offsetWidth);
        }
    }

    let html = '<table>';

    // Add a row with the 'Total' header
    html += '<tr><th colspan=""' + dataGrid[0].length + '"">Total</th></tr>';

    // Add the row with the summations
    html += '<tr>';
    for (let j = 0; j < dataGrid[0].length; j++) {
		let style = 'style=""width: ' + columnWidths[j] + 'px""'; // Apply the fetched width
        if (j == 0) {
            html += '<td ' + style + '></td>'; // The first cell will be empty
        } else if (j == dataGrid[0].length - 1) {
            html += '<td ' + style + '></td>'; // Last 'Select' column, so add an empty cell
        } else {
            let sum = '0-0-0';
            for (let i = 1; i < dataGrid.length; i++) {
				let valueStr = dataGrid[i][j].toString(); // Ensure it's a string
				
                // Consider only rows with 'Select' as true
				if (dataGrid[i][dataGrid[i].length - 1] === 'true') {
					if (valueStr.includes('-')) {						
						sum = sumKanalMarlaFeet(valueStr, sum);
					} else {
						let value = parseFloat(valueStr);
						if (!isNaN(value)) { // Check if it's a number
							sum = (parseInt(sum) + value).toString();
						}
					}
				}
			}
            html += '<td ' + style + '>' + sum + '</td>';
        }
    }
    html += '</tr>';
	
    html += '</table>';
    return html;
}




function generateHTMLTable(dataGrid) {
    let html = '<table>';

	for (let i = 0; i < dataGrid.length; i++) {
		html += '<tr>';

		for (let j = 0; j < dataGrid[i].length; j++) {
			
			if (i === 0) {
				var arrowToAppend = '';
				// Headers with attached click event
				if(dataGrid[i][j] == lastSortedColumnName){
					arrowToAppend = lastSortedDirection;
				}
					
				if(dataGrid[i].length-1 == j) {
					html += '<th onclick=\'selectClicked(event)\' style=\'cursor:pointer;\'>' + dataGrid[i][j] + arrowToAppend + '</th>';
				} else {
					html += '<th onclick=\'headerClicked(event)\' style=\'cursor:pointer;\'>' + dataGrid[i][j] + arrowToAppend + '</th>';
				}
					
			} else {
				if (j === dataGrid[i].length - 1) {
					// Add the checkbox based on the last element's value
					let checkbox = (dataGrid[i][j] === 'true') 
						? '<input type=\'checkbox\' checked onclick=\'checkboxClicked(event, ' + i + ')\'>'
						: '<input type=\'checkbox\' onclick=\'checkboxClicked(event, ' + i + ')\'>';

					html += '<td>' + checkbox + '</td>';
				} else {
					// Regular data
					html += '<td>' + dataGrid[i][j] + '</td>';
				}
			}
		}

		html += '</tr>';
	}
	
    html += '</table>';
	
    return html;
}


function addSelectColumn(grid) {
    // Clone the input grid to avoid modifying it directly
    let modifiedGrid = JSON.parse(JSON.stringify(grid));
    
    // Add 'Select' to the header
    modifiedGrid[0].push('Select');
    
    // Add 'true' to the end of each subsequent row
    for (let i = 1; i < modifiedGrid.length; i++) {
        modifiedGrid[i].push('true');
    }

    return modifiedGrid;
}

function synchronizeColumnWidths() {
    const mainTableRows = document.querySelector('#tableContainer table').rows;
    const totalsTableRows = document.querySelector('#totalsContainer table').rows;

    if (mainTableRows.length > 0 && totalsTableRows.length > 0) {
        const mainHeaderCells = mainTableRows[0].cells;
        const totalsHeaderCells = totalsTableRows[0].cells;

        for (let i = 0; i < mainHeaderCells.length; i++) {
            const width = mainHeaderCells[i].offsetWidth;
            if (totalsHeaderCells[i]) {
                totalsHeaderCells[i].style.width = `${width}px`;
            }
        }
    }
}


	
</script>

</body>
</html>
";

    return cSharpHtml;
}


}
