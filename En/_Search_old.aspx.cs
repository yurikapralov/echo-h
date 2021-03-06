using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using echo.BLL;
using echo.BLL.Info;
using echo.BLL.Products;

public partial class En_Search_old : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCurrency(Currency);
            Sort = ProductSorted.DateAsc;
            int count = BindProducts();
            pnlNavigation.Visible = (count != 0);
            lblCounts.Text = string.Format("Total goods: {0}", count);
            SetDefultPageSize();

            LoadHeadersData();
        }
        Master.ContentStyle = "Content2";
    }

    protected void BindCurrency(string value)
    {
        using (RateRepository lRepository = new RateRepository())
        {
            List<Rate> rates = lRepository.GetRates();
            ddlCurrency.DataSource = rates;
            ddlCurrency.DataBind();
            ddlCurrency.Items.Insert(0, new ListItem("Rub", "0"));
            ddlCurrency.SelectedValue = value;
        }
    }

    protected void lvProducts_PagePropertiesChanged(object sender, EventArgs e)
    {
        BindProducts();
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetPageSize();
        BindProducts();
    }
    protected void NameASC_Click(object sender, EventArgs e)
    {
        Sort = ProductSorted.NameAsc;
        BindProducts();
        ChangeLinkButtonProperty((LinkButton)sender);
    }
    protected void NameDESC_Click(object sender, EventArgs e)
    {
        Sort = ProductSorted.NameDesc;
        BindProducts();
        ChangeLinkButtonProperty((LinkButton)sender);
    }
    protected void PriceASC_Click(object sender, EventArgs e)
    {
        Sort = ProductSorted.PriceAsc;
        BindProducts();
        ChangeLinkButtonProperty((LinkButton)sender);
    }
    protected void PriceDESC_Click(object sender, EventArgs e)
    {
        Sort = ProductSorted.PriceDesc;
        BindProducts();
        ChangeLinkButtonProperty((LinkButton)sender);
    }
    protected void DateASC_Click(object sender, EventArgs e)
    {
        Sort = ProductSorted.DateAsc;
        BindProducts();
        ChangeLinkButtonProperty((LinkButton)sender);
    }
    protected void DateDESC_Click(object sender, EventArgs e)
    {
        Sort = ProductSorted.DateDesc;
        BindProducts();
        ChangeLinkButtonProperty((LinkButton)sender);
    }

    protected void ChangeLinkButtonProperty(LinkButton lbtn)
    {
        List<LinkButton> linkButtons = new List<LinkButton>();
        linkButtons.Add(NameASC);
        linkButtons.Add(NameDESC);
        linkButtons.Add(DateASC);
        linkButtons.Add(DateDESC);
        linkButtons.Add(PriceASC);
        linkButtons.Add(PriceDESC);

        foreach (LinkButton linkButton in linkButtons)
        {
            if (lbtn == linkButton)
            {
                linkButton.Font.Underline = false;
                linkButton.Enabled = false;
                linkButton.Font.Bold = true;
            }
            else
            {
                linkButton.Font.Underline = true;
                linkButton.Enabled = true;
                linkButton.Font.Bold = false;
            }
        }
    }

    protected string DescRestrict(object oDescription)
    {
        if (oDescription == null)
            return "";
        string description = (string)oDescription;
        int numberOfLetters = 150;

        if (description.Length < numberOfLetters)
            return description;

        return description.Substring(0, numberOfLetters) + "...";
    }

    protected void SetPageSize()
    {
        int allCount = int.Parse(ddlPageSize.SelectedValue);
        if (allCount == 0)
            allCount = BindProducts();
        pagerBottom.SetPageProperties(0, allCount, false);
    }

    protected void SetDefultPageSize()
    {

        ddlPageSize.SelectedValue = "8";
        pagerBottom.SetPageProperties(0, 8, false);

    }

    protected int BindProducts()
    {
        using (ProductRepository lRepository = new ProductRepository())
        {
            List<Product> lProducts = new List<Product>();
            if (SearchText != "")
            {
                lProducts = lRepository.GetSearchProducts(SearchText, Sort, ProdType);
                lvProducts.DataSource = lProducts;
                lvProducts.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            if (lProducts.Count <= pagerBottom.PageSize)
            {
                pnlPager.Visible = false;
            }
            else
            {
                pnlPager.Visible = true;
            }
            return lProducts.Count;
        }
    }



    protected void LoadHeadersData()
    {

        Master.HeaderImage = "Header.jpg";
        Master.MainHeader = "Search for clothes and shoes - 'Echo Of Hollywood' online store";
        Master.Title = "Search for clothes and shoes - 'Echo Of Hollywood' online store";
        lblDescription.Text = string.Format("Search results: '{0}'", SearchText);

    }

    protected string formatFunction(object obj, bool isShow)
    {
        int i = (int)obj;
        if (isShow)
            return "ShowPreview('img_block_" + i.ToString() + "');";
        return "HidePreview('img_block_" + i.ToString() + "');";
    }

    protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Currency"] = ddlCurrency.SelectedValue;
        BindProducts();
    }
}
