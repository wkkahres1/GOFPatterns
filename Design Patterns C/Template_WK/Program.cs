using System;

/// <summary>
/// This code demonstrates how a document reader will use the
/// correct kind of interpreter to either read a PDF or RTF
/// </summary>
namespace Template_WK
{
    /// <summary> 
    /// Template Method Pattern.
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            // TODO
            // Create PDF DocumentReader
            Console.WriteLine("---- Document Reader of Type - PDF ----");
            DocumentReader documentReader = new PDFDocument();
            documentReader.OpenDocument();

            // Create PDF DocumentReader
            Console.WriteLine("---- Document Reader of Type - RTF ----");
            documentReader = new RTFDocument();
            documentReader.OpenDocument();

        }
    }

    //'AbstractClass' abstract class
    abstract class DocumentReader
    {
        //default steps 
        public void LoadFile()
        {
            Console.WriteLine("Document File loaded");
        }

        // steps that will be overidden by subclass
        public abstract void InterpretDocumentFormat();

        // default step
        public void Open()
        {
            Console.WriteLine("Document File opens");
        }

        //'Template Method'
        public void OpenDocument()
        {
            this.LoadFile();
            this.InterpretDocumentFormat();
            this.Open();
        }

    }
    //'ConcreteClass'- concrete class
    class PDFDocument : DocumentReader
    {
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with " +
                                "PDF Interpreter");
        }
    }

    //'ConcreteClass' - concrete class
    class RTFDocument : DocumentReader
    {
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with " +
                                "RTF Interpreter");
        }
    }
}