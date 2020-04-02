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

//we need code that unzips the writer document

//-- from a helpful post by Porkopek on Stack Overflow --
/// <summary>
    /// Gets all plain text from an .odt file
    /// </summary>
    /// <param name="path">
    /// the physical path of the file
    /// </param>
    /// <returns>a string with all text content</returns>
    public String GetTextFromOdt(String path)
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

            //Append both text variables
            sb.Append(stylesText + "\r\n");
            sb.Append(mainText);
        }




        return sb.ToString();
    } 

//replaces the placeholders with the current values in one of the containing xml files
    public String GetTextFromXml(String path)
    {
        
        //returns text
    }
    public String ReplacePlaceholders(String text)
    {
        
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
