﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using echo.BLL;
using echo.BLL.Products;

public partial class Admin_Cathegories : AdminPage
{
    private string _uploadPath;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Master.Title = "Управление категориями";
            Master.HeaderText = "Управление категориями";
            BindGroups(ddlGroup, true);
            BindGroups(ddlGroupForEdit, false);
            BindTemplates();
        }
        _uploadPath = Server.MapPath("~/Images/Headers/");
    }

    public CathegorySortField SortField
    {
        get
        {
            if (ViewState["CathegorySortField"] != null)
                return (CathegorySortField)ViewState["CathegorySortField"];
            return CathegorySortField.DateCreated;
        }
        set
        {
            ViewState["CathegorySortField"] = value;
        }
    }

    public CathegorySortType SortType
    {
        get
        {
            if (ViewState["CathegorySortType"] != null)
                return (CathegorySortType)ViewState["CathegorySortType"];
            return CathegorySortType.Asc;
        }
        set
        {
            ViewState["CathegorySortType"] = value;
        }
    }

    protected void BindGroups(DropDownList control, bool added)
    {
        using (GroupRepository lRepository = new GroupRepository())
        {
            List<Group> groups = lRepository.GetGroups();
            control.DataSource = groups;
            control.DataBind();
            if (added)
            {
                control.Items.Insert(0, new ListItem("Выберите группу", "-1"));
                control.Items.Insert(1, new ListItem("Все группы", "0"));
            }
        }
    }


    protected void BindTemplates()
    {
        using (TemplateRepository lRepository = new TemplateRepository())
        {
            List<Template> templates = lRepository.GetTemplates();
            ddlTemplate.DataSource = templates;
            ddlTemplate.DataBind();
        }
    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCategories();
        ListItem finded = ddlGroup.Items.FindByValue("-1");
        if (finded != null)
            ddlGroup.Items.Remove(finded);
    }

    protected void BindCategories()
    {
        using (CathegoryRepository lRepository = new CathegoryRepository())
        {
            List<Cathegory> lcategories = null;
            int groupId = int.Parse(ddlGroup.SelectedValue);
            if (groupId > 0)
            {
                lcategories = lRepository.GetCathegoryByGroup(groupId, SortField, SortType);
            }
            else
            {
                lcategories = lRepository.GetCathegories(SortField, SortType);
            }
            lvCategories.DataSource = lcategories;
            lvCategories.DataBind();
            if (lcategories.Count < pagerBottom.PageSize)
                pnlPager.Visible = false;
            else
                pnlPager.Visible = true;
        }
    }




    protected void lbtSorted_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        CathegorySortField selSortField = (CathegorySortField)Enum.Parse(typeof(CathegorySortField), lbtn.CommandArgument);


        if (SortField == selSortField)
        {
            if (SortType == CathegorySortType.Asc)
                SortType = CathegorySortType.Desc;
            else
                SortType = CathegorySortType.Asc;
        }
        else
        {
            SortField = selSortField;
            SortType = CathegorySortType.Asc;
        }
        BindCategories();
    }
    protected void lvCategories_PagePropertiesChanged(object sender, EventArgs e)
    {
        BindCategories();
    }

    protected void lbtnSelect_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        int categoryId = int.Parse(lbtn.CommandArgument);
        BindCategory(categoryId);
    }

    protected void BindCategory(int categoryId)
    {
        using (CathegoryRepository lRepository = new CathegoryRepository())
        {
            CategoryId = categoryId;
            Cathegory cathegory = lRepository.GetCathegoryById(categoryId);
            lblEditHeader.Text = string.Format("Редактирование категории: {0}, ID: {1}", cathegory.CatNameRus,
                                          cathegory.CatID);
            txtCatNameRus.Text = cathegory.CatNameRus;
            txtCatNameEng.Text = cathegory.CatNameEng;
            ddlGroupForEdit.SelectedValue = cathegory.GroupId.ToString();
            ddlTemplate.SelectedValue = cathegory.TemplateId.ToString();
            txtDescriptionRus.Text = cathegory.DescriptionRus;
            txtDescriptionRus2.Text = cathegory.Description2Rus;
            txtDescriptionEng.Text = cathegory.DescriptionEng;
            cbkActive.Checked = cathegory.ActiveStatus;
            cbkMarked.Checked = cathegory.Marked;
            txtCatOrder.Text = cathegory.CatOrder.ToString();
            txtMetaTitle.Text = cathegory.GroupTitle;
            txtMetaDescription.Text = cathegory.MetaDescription;
            txtMetaKeywords.Text = cathegory.MetaKeywords;
            btnAddCathegory.Text = "Изменить";
            cbxInGroupLink.Checked = cathegory.InGeneralLink;
        }
    }

    protected void ClearCathegory()
    {
        lvCategories.SelectedIndex = -1;
        CategoryId = 0;
        lblEditHeader.Text = "Добавление новой категории";
        btnAddCathegory.Text = "Добавить";
        txtCatNameRus.Text = "";
        txtCatNameEng.Text = "";
        ddlGroupForEdit.SelectedIndex = -1;
        ddlTemplate.SelectedIndex = -1;
        txtDescriptionRus.Text = "";
        txtDescriptionRus2.Text = "";
        txtDescriptionEng.Text = "";
        cbkActive.Checked = true;
        cbkMarked.Checked = false;
        txtCatOrder.Text = "1";
        txtMetaTitle.Text = "";
        txtMetaDescription.Text = "";
        txtMetaKeywords.Text = "";
        cbxInGroupLink.Checked = true;
        BindCategories();
    }


    protected void lvCategories_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        lvCategories.SelectedIndex = e.NewSelectedIndex;
        BindCategories();
    }


    protected void UpdateCathegory()
    {
        using (CathegoryRepository lRepository = new CathegoryRepository())
        {
            Cathegory cathegory;
            if (CategoryId > 0)
            {
                cathegory = lRepository.GetCathegoryById(CategoryId);
                cathegory.DateUpdated = DateTime.Now;
            }

            else
            {
                cathegory = new Cathegory();
                cathegory.DateCreated = DateTime.Now;
            }

            cathegory.CatNameRus = txtCatNameRus.Text;
            cathegory.CatNameEng = txtCatNameEng.Text;
            cathegory.DescriptionRus = txtDescriptionRus.Text;
            cathegory.Description2Rus = txtDescriptionRus2.Text;
            cathegory.DescriptionEng = txtDescriptionEng.Text;
            cathegory.ActiveStatus = cbkActive.Checked;
            cathegory.Marked = cbkMarked.Checked;
            cathegory.CatOrder = int.Parse(txtCatOrder.Text);
            cathegory.GroupTitle = txtMetaTitle.Text;
            cathegory.MetaDescription = txtMetaDescription.Text;
            cathegory.MetaKeywords = txtMetaKeywords.Text;
            cathegory.InGeneralLink = cbxInGroupLink.Checked;
            if (cathegory.Template == null || cathegory.Template.TempleID != int.Parse(ddlTemplate.SelectedValue))
                cathegory.TemplateId = int.Parse(ddlTemplate.SelectedValue);
            if (cathegory.Group == null || cathegory.Group.GroupID != int.Parse(ddlGroupForEdit.SelectedValue))
                cathegory.GroupId = int.Parse(ddlGroupForEdit.SelectedValue);

            cathegory = lRepository.AddCathegory(cathegory);
        }
    }

    protected void btnCancelCathegory_Click(object sender, EventArgs e)
    {
        ClearCathegory();
    }
    protected void btnAddCathegory_Click(object sender, EventArgs e)
    {
        UpdateCathegory();
        ClearCathegory();
        MenuCreator.GenerateRusXmlMenu();
        MenuCreator.GenerateEngXmlMenu();
        MenuCreator.GenerateSiteMap();
    }

    

    
    protected void lvCategories_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        int catId = int.Parse(lvCategories.DataKeys[e.ItemIndex].Value.ToString());
        //todo: сделать корректное удаление катетегорий и коллекций.
        /*using(CollectionRepository lCollectionRepository=new CollectionRepository())
        {
            lCollectionRepository.DeleteCollectionByCat(catId);
        }*/
        using (CathegoryRepository lRepository = new CathegoryRepository())
        {

            lRepository.DeleteCathegory(catId);
            BindCategories();
            MenuCreator.GenerateRusXmlMenu();
            MenuCreator.GenerateEngXmlMenu();
            MenuCreator.GenerateSiteMap();
        }
    }


    protected void btnGenerateMenu_Click(object sender, EventArgs e)
    {
        MenuCreator.GenerateRusXmlMenu();
        MenuCreator.GenerateEngXmlMenu();
        MenuCreator.GenerateSiteMap();
    }
}