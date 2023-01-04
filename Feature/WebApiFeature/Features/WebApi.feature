Feature: WebApi

@Upload
Scenario: Upload file
	Given check file exists on pc
	When upload file
	Then show success message

@Metadata
Scenario: Show file metada
	Given file exists on Dropbox
	When get file metada
	Then show file metada

@Delete
Scenario: Delete file
	Given file exists on Dropbox
	When delete file
	Then show delete success message