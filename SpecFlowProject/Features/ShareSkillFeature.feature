Feature: ShareSkillFeature

As a MarsQA user, I should be able to add share skill details to my profile 
@tag1
Scenario Outline: Add share skill details 
	Given Being logged in to MarsQA and on my profile 
	When Add share skill details with Json data located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AddShareSkillData.json"
	Then I should be able to add details to share skills section

Scenario: Try to add share skill with manadatory fileds empty
	Given Being logged into MarsQA and on my profile 
	When Add share sill details with mandatory fields empty as per Json data located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\ShareSkillInvalidInputData.json"
	Then I should not be able to add share skills while mandatory fields are empty 
