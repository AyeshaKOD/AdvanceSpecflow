Feature: DescriptionFeature1

As a registered MarsQA user, i should be able to add, update and delete description in my profile 
@tag1
Scenario Outline: Add/update description  section in my profile 
	Given Being logged into MarsQA profile 
	And Click description edit icon in my profile 
	When Add description with json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\DescriptionData.json"
	Then Should be able to successfully add description


	Scenario: Delete description
	Given Being logged in to MarsQA profile 
	And Click description edit icon in my profile 
	When Delete description with json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\DeleteDescription.json"
	Then Should be able to successfully delete description 

Scenario: Add description with special characters and numerals 
	Given Being logged in to MarsQA profile 
	And Click description edit icon in my profile 
	When Add description with special characters and numerals with json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\SpecialCharacterDescriptionData.json"
	Then Should be able to successfully add description with numerals and special characters 
