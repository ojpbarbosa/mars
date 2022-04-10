using System;
using System.Windows.Forms;

namespace apMarte
{
  public partial class FormMarte : Form
  {
    public FormMarte()
    {
      InitializeComponent();
    }

    private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void tabPage1_Click(object sender, EventArgs e)
    {

    }

    private void FrmAgenda_Load(object sender, EventArgs e)
    {
      int indice = 0;
      toolStrip.ImageList = botoesImageList;

      foreach (ToolStripItem item in toolStrip.Items)
      {
        if (item is ToolStripButton)
        {
            (item as ToolStripButton).ImageIndex = indice++;
        }
      }
    }
  }
}
