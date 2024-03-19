Feature: LoginFeature1

As a registered Mars QA user i should be able to login to Mars QA successfully 

@tag1
Scenario: Login with valid credential
	Given I should be on MarsQA page 
	When I enter valid credential with Json file located in "C:\IndustryConnect\AdvanceSpecflow\AdvanceSpecflow\SpecFlowProject\JsonData\UserInformationData.json"
	Then I should be able to login successfully 
