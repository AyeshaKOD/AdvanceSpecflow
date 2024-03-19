Feature: ManageListingFeature

As a registered MarsQA user, i should be able to view, update and delete skills that i have been added to my profile 

@tag1
Scenario Outline: Update listing 
	Given Being logged in to Mars QA 
	When Add share skill details to my profile with Json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AddShareSkillData.json"
	And  update skill data using '<UpdateManageListing>'
	Then Skill should be updated 

Examples: 
| UpdateManageListing|
| C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\UpdateManageListingData.json |


Scenario Outline: Delete listing 
	Given Being logged in to MarsQA profile
	When Add share skill details to my profile with Json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AddShareSkillData.json"
	And Delete a skill available as per '<DeleteManageListing>'
	Then Relevant skill should be deleted

Examples: 
| DeleteManageListing|
|C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\DeleteListingData.json|


Scenario Outline: View listing 
	Given Being logged in to MarsQA profile 
	When Add share skill details to my profile with Json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AddShareSkillData.json"
	And View skill as per '<ViewManageListing>'
	Then should be able to view the selected skill

Examples: 
| ViewManageListing|
|C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\ViewSkillData.json|


Scenario Outline: skill pagination
	Given Being logged in to Mars QA 
	When Add share skill details to my profile with Json file located at "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\AddShareSkillData.json"
	And Search for a skill using '<Pagination>'
	Then Should be able to find the searched skill

Examples: 
| Pagination|
|C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\PaginationData.json|

Scenario Outline: Activate or deactivate a skill
	Given Being logged in to MarsQA profile
	When Click toggle button from listing '<ActiveButton>'
	Then Should be able to either activate or deactivate the selected skill

Examples: 
| ActiveButton|
| C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\ActiveButtonListingData.json|

