﻿using Embily.Gateways.DHL.Model.req;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Embily.Gateways.DHL.Model
{
    public partial class RequestCalculateRates
    {
        [JsonProperty("?xml")]
        public Xml Xml { get; set; }

        [JsonProperty("p:DCTRequest")]
        public PDctRequest PDctRequest { get; set; }
    }

//    <? xml version="1.0" encoding="UTF-8"?>
//<p:DCTRequest xmlns:p="http://www.dhl.com" xmlns:p1="http://www.dhl.com/datatypes" xmlns:p2="http://www.dhl.com/DCTRequestdatatypes" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://www.dhl.com DCT-req.xsd ">
//  <GetQuote>
//    <Request>
//      <ServiceHeader>
//        <MessageTime>2002-08-20T11:28:56.000-08:00</MessageTime>
//        <MessageReference>1234567890123456789012345678901</MessageReference>
//            <SiteID>DServiceVal</SiteID>
//            <Password>testServVal</Password>
//      </ServiceHeader>
//    </Request>
//    <From>
//      <CountryCode>SG</CountryCode>
//      <Postalcode>100000</Postalcode>
//    </From>
//    <BkgDetails>
//      <PaymentCountryCode>SG</PaymentCountryCode>
//      <Date>2016-08-24</Date>
//      <ReadyTime>PT10H21M</ReadyTime>
//      <ReadyTimeGMTOffset>+01:00</ReadyTimeGMTOffset>
//      <DimensionUnit>CM</DimensionUnit>
//      <WeightUnit>KG</WeightUnit>
//      <Pieces>
//        <Piece>
//          <PieceID>1</PieceID>
//          <Height>1</Height>
//          <Depth>1</Depth>
//          <Width>1</Width>
//          <Weight>5.0</Weight>
//        </Piece>
//      </Pieces> 
//	  <PaymentAccountNumber>CASHSIN</PaymentAccountNumber>	  
//      <IsDutiable>N</IsDutiable>
//      <NetworkTypeCode>AL</NetworkTypeCode>
//	  <QtdShp>
//		 <GlobalProductCode>D</GlobalProductCode>
//	     <LocalProductCode>D</LocalProductCode>		
//	     <QtdShpExChrg>
//            <SpecialServiceType>AA</SpecialServiceType>
//         </QtdShpExChrg>
//	  </QtdShp>
//    </BkgDetails>
//    <To>
//      <CountryCode>AU</CountryCode>
//      <Postalcode>2007</Postalcode>
//    </To>
//   <Dutiable>
//      <DeclaredCurrency>EUR</DeclaredCurrency>
//      <DeclaredValue>1.0</DeclaredValue>
//    </Dutiable>
//  </GetQuote>
//</p:DCTRequest>
}
