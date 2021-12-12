using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using pdf2jpg;

public class FileLoader : MonoBehaviour {

    // Use this for initialization
    void Start () {
        String sourceFilePath = "./Assets/pdfBooks/harrypotter.pdf";
        String outputFolderPath = "./Assets/editPDF";
        PDDocument doc = PDDocument.load(sourceFilePath);
        DirectoryInfo di = new DirectoryInfo(outputFolderPath);
        if(di.Exists ==false) di.Create();
        Splitter splitter = new Splitter();
        java.util.List pages = splitter.split(doc);
        PDDocument docu1 = (PDDocument)pages.get(1);
        PDDocument docu2 = (PDDocument)pages.get(1);
        docu1.save(outputFolderPath+"/"+"test1.pdf");
        docu2.save(outputFolderPath+"/"+"test2.pdf");
        //pdf2jpg1 pdf2j = new pdf2jpg1();
        //pdf2j.change(outputFolderPath+"/"+"test1.pdf",outputFolderPath);
        docu1.close();
        docu2.close();

        
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    

}

