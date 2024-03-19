Feature: ProfileAboutMeFeature

As a registered MarsQA user , i should be able to add details under about me section of my profile 

@tag1
Scenario Outline: Add firstname and last name 
	Given Being logged into Mars QA 
	When Add first name and last name with json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AboutMeData.json"
	Then Should be able to successfully add my first name and last name 


Scenario: Select availability from drop down list 
	Given Being logged into MarsQA profile
	When Select availability option from drop down list with json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AvailabilityData.json"
	Then Should be able to suucessfully update my availability

Scenario: Select hours i am available 
	Given Being logged into MarsQA profile 
	When Select number of hours i am available with json file "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\HoursData.json"
	Then Should be able to successfully update number of hours 


Scenario: Select earn target 
	Given Being logged into MarsQA profile 
	When Select monthly earn target with json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\EarnTargetData.json"
	Then Should be able to successfully update my monthly earn target 