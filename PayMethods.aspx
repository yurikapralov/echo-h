﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Theme2.master" AutoEventWireup="true" CodeFile="PayMethods.aspx.cs" Inherits="PayMethods" Theme="Theme2" %>
<%@ MasterType VirtualPath="~/Theme2.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" Runat="Server">
<h2>При курьерской доставке</h2>
<p>Оплата происходит в момент передачи заказа курьером.</p>
<h2>При оплате наложенным платежем</h2>
<p>Оплата происходит при получении заказа в отделение Почты России по вашему адресу. Оплата наложенным платежом возможна только при условии <strong>доставки почтой по России.</strong></p>
<p><ul>Стоимость заказа при оплате способом наложенного платежа складывается из:
<li>Заявленной стоимости заказа (то есть стоимости заказанных Вами товаров).</li>
<li>Почтового тарифа, определяемого в зависимости от веса и расстояния.</li>
<li>3%-ного почтового страхового сбора, определяемого от заявленной стоимости посылки и НДС с общей суммы сборов за посылку.</li>
</ul> 
<p class="ErrorNote">Внимание! При получении и оплате заказа, доставленного наложенным платежом, взимается плата по тарифу на пересылку внутренних простых почтовых переводов. 
Процент оплаты зависит от пересылаемой суммы и не зависит от технологии пересылки денежных средств. 
Более подробно ознакомиться с тарифами Вы можете на сайте <a href="http://www.russianpost.ru/portal/ru/home/financial/cybermoney_russia" class="ErrorNote" target="_blank">Федеральной Почтовой службы</a></p>
</p>
<h2>При заказе по предоплате</h2>
<div id="prepaid">
<h3 class="paymethods">Банковские реквизиты</h3>
<p>
    ООО 'ЭХО XXI'<br>
    Почтовый адрес: 105215, г.Москва, ул. 9-я Парковая д.66, к. 1, офис 8.<br>
    Юридический адрес: 107076, г.Москва, ул. Краснобогатырская, д.90, стр.2.<br>
    ИНН 7718251860<br>
    КПП 771801001<br>
    Р\С 40702810238290106392<br>
   Московский банк Сбербанка России  ОАО 'Сбербанк России'  г.Москва  БИК 044525225<br>
   К/Сч 30101810400000000225<br>
    </p>
    <p>
        <a href="Docs/echo_sber.rtf">Скачать квитанцию на оплату через сбербанк</a>
    </p>
<div id="st-accordion" class="st-accordion">
    <ul>
        <li>
            <a href="#">
                Оплата через платежную систему Qiwi
                <span class="st-arrow">Open or Close</span>
            </a>
            <div class="st-content">
                <iframe id="qiwi_frame" src="Docs/qiwi.html">

                </iframe>
                

            </div>
        </li>
    </ul>
     <!--<a href="Docs/yandex_mon.htm" class="pseudoacc" target="blank">
                Оплата через платежную систему Yandex Money
                
            </a>-->
</div>
</div>
</asp:Content>
