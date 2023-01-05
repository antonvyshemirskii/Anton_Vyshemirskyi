using System;
using TechTalk.SpecFlow;
using FluentAssertions;

using WebApi;

namespace WebApiFeature.Features
{
    [Binding]
    public class WebApiSteps
    {
        
        DbUpload dbUpload = new DbUpload();

        [Given(@"check file exists on pc")]
        public void GivenCheckFileExistsOnPc()
        {
            dbUpload.IsFileExist();
        }

        [When(@"upload file")]
        public void WhenUploadFile()
        {
            dbUpload.UploadFile();
        }

        [Then(@"show success message")]
        public void ThenShowSuccessMessage()
        {
            dbUpload.ShowSuccessMessage();
        }


        
        DbMetaData dbMeta = new DbMetaData();
        [Given(@"file exists on Dropbox")]
        public void GivenFileExistsOnDropbox()
        {
            dbMeta.IsFileExist();
        }
        
        [When(@"get file metada")]
        public void WhenGetFileMetada()
        {
            dbMeta.GetFileMetaData();
        }

        [Then(@"show file metada")]
        public void ThenShowFileMetada()
        {
            dbMeta.ShowSuccessMessage();
        }

        
        DbDelete dbDelete = new DbDelete();
        [When(@"delete file")]
        public void WhenDeleteFile()
        {
            dbDelete.DeleteFile();
        }
        
        [Then(@"show delete success message")]
        public void ThenShowDeleteSuccessMessage()
        {
            dbDelete.ShowSuccessMessage();
        }
    }
}
