using System;
using TechTalk.SpecFlow;
using FluentAssertions;

using WebApi;

namespace WebApiFeature.Features
{
    [Binding]
    public class WebApiSteps
    {
        // Dropbox uploader class
        DropboxUploader dbu = new DropboxUploader();

        [Given(@"check file exists on pc")]
        public void GivenCheckFileExistsOnPc()
        {
            dbu.CheckFileExist();
        }

        [When(@"upload file")]
        public void WhenUploadFile()
        {
            dbu.UploadFile();
        }

        [Then(@"show success message")]
        public void ThenShowSuccessMessage()
        {
            dbu.ShowSuccessMessage();
        }


        // Get file metadata
        DropboxFileMetadata dfm = new DropboxFileMetadata();
        [Given(@"file exists on Dropbox")]
        public void GivenFileExistsOnDropbox()
        {
            dfm.CheckFileExist();
        }
        
        [When(@"get file metada")]
        public void WhenGetFileMetada()
        {
            dfm.GetFileMetadata();
        }

        [Then(@"show file metada")]
        public void ThenShowFileMetada()
        {
            dfm.ShowSuccessMessage();
        }

        // Delete file
        DropboxFileDeleter dfd = new DropboxFileDeleter();
        [When(@"delete file")]
        public void WhenDeleteFile()
        {
            dfd.DeleteFile();
        }
        
        [Then(@"show delete success message")]
        public void ThenShowDeleteSuccessMessage()
        {
            dfd.ShowSuccessMessage();
        }
    }
}
