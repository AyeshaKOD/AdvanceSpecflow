Feature: EducationFeature

As registered Mars QA user i should be able to add, update and delete education details on my profile 
@tag1
Scenario: Add education 
	Given Login to Mars QA and stay on profile page 
	When Click education tab and add education details with data on Json file "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AddEducationData.json"
	Then Should be able to successfully add data
	
Scenario: Update education 
	Given Login to Mars QA and stay on profile page 
	#When Add education details with data on Json file "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AddEducationData.json"
	When  Update education details with data on JSon file "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\UpdateEducationData.json"
	Then Should be able to update education details successfully 


Scenario: Delete Education
	Given Login to Mars Qa and stay on profile page 
	When I add education details with data on Json file "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AddEducationData.json"
	And Remove details on the Json file "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\DeleteEducationData.json" from education section
	Then I should be able to successfully delete intended data 


Scenario: Add empty education
	Given Login to mARS QA and stay on profile page 
	When  I add education details without entering all required fields with Json file "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\EmptyEducationData.json"
	Then Error message should pops up asking to enter all the required details 