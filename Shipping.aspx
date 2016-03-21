﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Theme2.master" AutoEventWireup="true" CodeFile="Shipping.aspx.cs" Inherits="Shipping" Theme="Theme2" %>
<%@ MasterType VirtualPath="~/Theme2.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" Runat="Server">
<h2>Существуют 3 способа доставки: </h2>
    <p>1.по предоплате:<br/>
    1а. при помощи службы экспресс доставки (по России)<br/>
    стоимость доставки расчитывается автоматически при офрмлении заказа<br/>
    1б. при помощи службы экспресс доставки (по ближнему и дальнему зарубежью)<br/>
    стоимость доставки сообщается менеджером компании<br/>
    2. курьером (только по Москве) (до 40-го  размера включительно)<br/>
    стоимость доставки - 300 рублей<br/>
    3. наложенным платежом (по России)(до 40-го размера включительно, сумма заказа меньше 10000 руб.)<br/>
    стоимость доставки определяется почтой РФ.</p>
    <p>&nbsp;</p>
    <h2>Схема выполнения заказов:</h2>
    <p>1. Вы указываете ваши координаты по которым сотрудник компании связывается с вами.<br/>
    2. С Вами оговариваются детали заказа, способ доставки, стоимость*, и в случае предоплаты сообщаются наши банковские реквизиты.<br/>
    3а. По предоплате: Вы оплачиваете счет через банк и по факту прихода денег мы отправляем ваш заказ по указанному вами адресу. 
    Доставка осуществляется в течении 3-5 рабочих дней в зависимости от региона.<br/>
    3б. Курьером: обговаривается время когда к Вам может подъехать курьер с товаром.<br/>
    3в. Наложенным платежом:по вашему адресу высылается товар, который получается и оплачивается на почте.<br/>
    Дополнительная информация по телефонам (499) 464-2365; (499)748-8584</p>
    <p>* - в стоимость входит: цена из каталога,  стоимость доставки<br/>
    - при размере больше 41-ого взымается надбавка за размер (600р.)</p>
    <p>&nbsp;</p>
    <!--
    <h2>Доставка товаров из  США, Китай (Pleaser, Ellie Shoes, Kotonica, Highest Heel, Karo's Shoes):</h2>
    <p>Выполнение Вашего заказа осуществляется после стопроцентной предоплаты за товар.
    Оплата производится только после  звонка нашего менеджера для подтверждения заказа.
    Доставка товара клиенту осуществляется непосредственно из США службой экспресс доставки USPS Express Mail, 
    по указанному Вами адресу.</p>
    <p>Представительство этой службы  в России — EMS Почта России.</p>
    <p>После отправки заказа мы сообщим Вам № почтового отправления, 
    по которому Вы можете отслеживать процесс доставки на сайте: <a href="http://www.emspost.ru">http://www.emspost.ru</a></p>
    <p>Доставка из США занимает 10-20 рабочих дней, в зависимости от региона Вашего проживания.</p>
    <p>Стоимость доставки зависит от количества заказанных Вами товаров.</p>
    <table style="border: 1px dotted #000; color: #676767; font: 12px Arial; border-collapse: collapse" cellpadding="5">
    <tr>
    <td style="font-weight:bold; border: 1px dotted #000;">Кол-во товаров</td>
    <td style="font-weight:bold; border: 1px dotted #000;">Стоимость доставки<br /> (босоножки, туфли)</td>
    <td style="font-weight:bold; border: 1px dotted #000;">Стоимость доставки<br /> (сапоги, ботильоны, ботфорты)</td>
    </tr>
    <tr>
    <td style="border: 1px dotted #000;">1</td>
    <td style="border: 1px dotted #000;">1200,00 руб</td>
    <td style="border: 1px dotted #000;">1850,00 руб</td>
    </tr>
    <tr>
    <td style="border: 1px dotted #000;">2</td>
    <td style="border: 1px dotted #000;">1600,00 руб</td>
    <td style="border: 1px dotted #000;">2450,00 руб</td>
    </tr>
    </table>
    <p>При заказе более двух позиций стоимость доставки калькулируется индивидуально.</p>-->
    <h2>Покупка в кредит</h2>
    <p>Для наших клентов появилась новая возможность: покупка товаров в кредит</p>
    <ul>Для совершения покупки вам нужно:
    <li>Выбрать товар</li>
    <li>Нажать кнопку "Купить в кредит"</li>
    <li>Оформить заказ с выбранным способом оплаты "Покупка в кредит"</li>
    <li>После оформления заказа заполнить заявку</li>
    <li>Получить решение</li>
    </ul>
    <p>Более подробная информация на сайте <a href="https://www.kupivkredit.ru/main/support" target="_blank" >КупиВкредит</a></p>
    <p>Внимание: кредит предоставляется только на продукцию Echo Of Hollywood на сумму более 3000 руб. (включая стоимость доставки).</p>
</asp:Content>

