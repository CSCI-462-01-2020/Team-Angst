//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       AJ_Will, ledbetterw, samlemonsam
//
// Copyright 2004-2019 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//

//-- TemplateWriter- a solution attempt for issue #456 --

//Imports
using System;
using System.Xml;
using System.Collections.Generic;
///using AODL.Document.TextDocuments;
///using AODL.Document.Content;

public class TemplateWriter
{
	//paths
	private String contentPath;//etc
	
	//
	private String contentText;//unedited content from ODT writer file- has text to replace
	private String styleText;//unedited style text from ODT writer file- may have text to replace
	
	//raw text
	private String metaText;//unedited meta text
	private String settingsText;//unedited settings text
	private String updatedContent;//updated content text
	private String updatedStyle;//updated style text
	
	//might not be correct way to make a list
	private String placeholders = [];//list of placeholders in XML document
	private String replacers = [];//list of replacers in XML document



//we need code that unzips the writer document

//-- from a helpful post by Porkopek on Stack Overflow --
/// <summary>
    /// Gets all plain text from an .odt file
    /// </summary>
    /// <param name="path">
    /// the physical path of the file
    /// </param>
    /// <returns>a string with all text content</returns>
    public void GetTextFromOdt(String path)
    {
        var sb = new StringBuilder();
        using (var doc = new TextDocument())
        {
            doc.Load(path);

            //The header and footer are in the DocumentStyles part. Grab the XML of this part
            XElement stylesPart = XElement.Parse(doc.DocumentStyles.Styles.OuterXml);
            //Take all headers and footers text, concatenated with return carriage
            string stylesText = string.Join("\r\n", stylesPart.Descendants().Where(x => x.Name.LocalName == "header" || x.Name.LocalName == "footer").Select(y => y.Value));

            //Main content
            var mainPart = doc.Content.Cast<IContent>();
            var mainText = String.Join("\r\n", mainPart.Select(x => x.Node.InnerText));

            //Append both text variables- dont actually append
            sb.Append(stylesText + "\r\n");
            sb.Append(mainText);
        }



		
        //return sb.ToString();
		
		//save in here instead
		
    } 

//replaces the placeholders with the current values in one of the containing xml files
    public void GetTextFromXml(String path)
    {
		string body = string.Empty;
   		string breakline = "<br />";
 
   		string Name = "Sponsor's Name";
    		string Receiver = "Child's Name";
    		string country = "Country";
    		string AccountId = "A0001";
		
	  	using (StreamReader reader = new StreamReader(Server.MapPath(path)))
    		{
        		body = reader.ReadToEnd();
    		}
 
    		body = body.Replace("{SenderFullName}", !string.IsNullOrEmpty(Name) ? SenderName + breakline : "");
    		body = body.Replace("{ReceiverFullName}", !string.IsNullOrEmpty(Receiver) ? Receiver + breakline : "");
    		body = body.Replace("{ReceiverCountry}", !string.IsNullOrEmpty(country) ? country + breakline : "");
    		body = body.Replace("{AccountId}", !string.IsNullOrEmpty(AccountId) ? AccountId + breakline : "");
    		this.lblId.Text = body;
		
        
    }
    public void ReplacePlaceholders(String text)
    {
        //save this.updatedContent
		
		//save this.updatedStyle
    }
//creates the writer document again with the updated xml files
    ///recieve
    public String CreateUpdatedOdt()
    {
        
        //return path to document
    }
//Then we return the writer document to the browser-not now
    
//Later we could print to pdf, probably using a local installation of libreoffice
    public String CreateUpdatedPdf()
    {
        
        //return path to document
    }
//return the pdf to the browser-not now

}
