﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Theme2.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" Theme="Theme2" %>

<%@ MasterType VirtualPath="~/Theme2.master" %>
<%@ Register Src="Controls/RandTop3NewProduct.ascx" TagName="NewProducts" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="extraContent" runat="server" ContentPlaceHolderID="extraNavHolder">
<%--    <a href="PayMethods.aspx">
        <img src="Images/Decoration/qiwi%20gorizontal.jpg" class="qiwi_image" />
        <img src="Images/Decoration/visa.jpg" class="qiwi_image" />
        
        
    </a>

    <a href="http://taxi-fantom.ru" target="_blank"><img src="Images/Decoration/logo-obmen.png" class="qiwi_image" /></a>--%>
</asp:Content>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="mainPlaceHolder">
        <div id="fb-root"></div>
        <script>    (function (d, s, id) {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (d.getElementById(id)) return;
                js = d.createElement(s); js.id = id;
                js.src = "//connect.facebook.net/ru_RU/sdk.js#xfbml=1&version=v2.3";
                fjs.parentNode.insertBefore(js, fjs);
            } (document, 'script', 'facebook-jssdk'));</script>
    <p>
        Интернет магазин женской обуви и одежды для шоу «Echo of Hollywood» приветствует
        Вас. На страницах нашего сайта вы найдете богатый ассортимент одежды, аксессуаров
        и <a href="/Products.aspx?CatId=0&GroupID=3" title="Обувь для стриптиза">обуви для стриптиза</a>,
        <a href="/Products.aspx?CatId=0&GroupID=3" title="Обувь для танцев">обуви для танцев</a>
        на пилоне и <a href="/Products.aspx?CatId=0&GroupID=3" title="Обувь для pole dance">обуви
            для pole dance</a>. Также у нас представлены модели для свадеб, праздничных и выпускных
        вечеров.</p>
    <p>
        Мы являемся производителями продукции бренда Echo of Hollywood. Все, начиная от
        дизайна и заканчивая готовым изделием, производится нами в России, в городе Москве.
        Поэтому у нас вы можете также купить женскую обувь оптом от производителя. Мы индивидуально
        подходим к любому заказу.</p>
    <p>
        Мы предлагаем нашим клиентам:</p>
    <ul>
        <li>богатый выбор материалов и натуральных кож, производства США, Англии и Италии.</li>
        <li>любое цветовое исполнение из имеющейся базы материалов.</li>
        <li>широкий размерный ряд женской обуви (от 34 размера по 44). В наших салонах вы сможете
            подобрать в том числе женскую обувь больших размеров.</li>
        <li>пошив женской обуви и одежды на заказ, по меркам.</li>
        <li>разнообразие продукции – от проверенных временем популярных моделей до ультрасовременных
            новинок.</li>
        <li>широкий разброс цен – для экономных и не очень покупателей.</li>
        <li>ознакомится с продукцией Echo of Hollywood вы можете на нашем сайте или в фирменных
            магазинах-салонах одежды и женской обуви «Echo of Hollywood" (Москва, Санкт-Петербург).</li>
    </ul>
    <div style="margin: 20px 50px;" class="fb-page" data-href="https://www.facebook.com/pages/%D0%9E%D0%B1%D1%83%D0%B2%D1%8C-%D0%AD%D0%A5%D0%9E-%D0%93%D0%BE%D0%BB%D0%BB%D0%B8%D0%B2%D1%83%D0%B4%D0%B0/1590525661184123" data-width="500" data-height="130" data-hide-cover="false" data-show-facepile="true" data-show-posts="false"></div>
    <h2>
        Новинки</h2>
    <a href="Products.aspx?CatId=54" class="flex_link">Все новинки</a>
    <div id="new_products">
        <uc1:NewProducts ID="NewProducts1" runat="server" Prod_mode="1" />
    </div>
    <div id="news_block">
        <h2>
            Новости</h2>
        <a href="#" class="flex_link">Все новости</a>
        <asp:Repeater ID="rptNews" runat="server">
            <ItemTemplate>
                <div class="news">
                    <span class="date">
                        <%#Eval("NewsDate","{0:d}") %></span>
                    <h4>
                        <%#Eval("Header") %></h4>
                    <p class="sel">
                        <%#Eval("Body") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <h2>
        Распродажа</h2>
    <div id="sale_products">
        <uc1:NewProducts ID="NewProducts2" runat="server" Prod_mode="2" />
    </div>
    <p>
        Для комфортного посещения нашего сайта ознакомьтесь с нижеследующим:</p>
    <p>
        Коллекции обуви и одежды Echo of Hollywood представлены в разделах и подразделах
        сайта. Каждое изделие имеет свой артикул и цвет, поэтому, если вы колеблетесь с
        выбором, запишите артикул и цвет понравившихся моделей, и наш специалист сможет
        вас проконсультировать по интересующим вопросам.</p>
    <p>
        Ознакомиться с новой коллекцией вы можете в разделе Новинки. Информация о доставке
        товара и способах оплаты указана в подразделе <a href="/Shipping.aspx" title="Способы доставки">
            Способы доставки</a>.</p>
    <p>
        Приглашаем к взаимовыгодному сотрудничеству руководителей клубов и танцевальных
        школ, арт-директоров, специалистов шоу-бизнеса, бизнесменов. Осуществляем производство
        обуви и одежды для шоу, презентаций, промоушн акций.</p>
    
    <!--<div id="advert" style="text-align:center;padding: 10px;"><img src="Images/Decoration/adv01.jpg" /></div>-->
</asp:Content>
