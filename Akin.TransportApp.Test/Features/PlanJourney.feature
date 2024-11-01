Feature: Plan a journey

    Here we are verifying the functionality of 'Plan a journey' page
Background: 
    Given the Transport application is launched
    When the user selects the 'Plan a journey' tab

Scenario Outline: Verify that a valid journey can be planned using the widget
    When the user enters and selects the departure location as '<From>'
    And the user enters and selects the destination as '<To>'
    And the user proceeds to plan the journey
    Then the journey results should be displayed
    And the user can see both walking time as '<WalkingTime>' and cycling time as '<CyclingTime>'

Examples: 
| From                         | To                        | WalkingTime | CyclingTime |
| Leicester Square Underground | Covent Garden Underground | 6mins       | 1mins       |

Scenario Outline: Verify that a valid journey can be edited with different preferences
    When the user enters and selects the departure location as '<From>'
    And the user enters and selects the destination as '<To>'
    And the user proceeds to plan the journey
    And the user edits the preferences
    And the user selects the "Show me" option '<ShowMe>'
    And the user updates the journey
    Then the journey results should be displayed
    And the user can see the journey time as '<JourneyTime>'

Examples: 
| From                         | To                        | ShowMe                    | JourneyTime |
| Leicester Square Underground | Covent Garden Underground | Routes with least walking | 10mins      |

Scenario Outline: Verify the complete access information for a valid journey
    When the user enters and selects the departure location as '<From>'
    And the user enters and selects the destination as '<To>'
    And the user proceeds to plan the journey
    When the user edits the preferences
    And the user selects the "Show me" option '<ShowMe>'
    And the user updates the journey
    Then the journey results should be displayed
    When the user clicks on View Details
    Then the user can see complete '<AccessInformation>' at '<To>'

Examples: 
    | From                         | To                        | ShowMe                    | AccessInformation               |
    | Leicester Square Underground | Covent Garden Underground | Routes with least walking | Up stairs,Up lift,Level walkway |

Scenario Outline: Verify that an invalid journey does not provide results
    When the user enters the departure location as '<From>'
    Then no data should be populated
    When the user enters the destination as '<To>'
    Then no data should be populated
    When the user proceeds to plan the journey
    Then the user can see both walking time as '<WalkingTime>' and cycling time as '<CyclingTime>'

Examples: 
| From             | To               | WalkingTime | CyclingTime |
| InvalidLocation1 | InvalidLocation2 | 0mins       | 0mins       |
| InvalidLocation3 | InvalidLocation4 | 0mins       | 0mins       |

Scenario Outline: Verify that the widget is unable to plan a journey for blank locations
    When the user enters the departure location as ''
    And the user enters the destination as ''
    And the user proceeds to plan the journey
    Then the user prompt with an error message as '<FromErrorMessage>' for 'From' location
    Then the user prompt with an error message as '<ToErrorMessage>' for 'To' location

Examples: 
| FromErrorMessage            | ToErrorMessage            |
| The From field is required. | The To field is required. |

#Additional Scenarios
#   Add few scenarios about what you would test, functional and 
#   non-functional, for this public facing component. (Do not write 
#   the automation tests, just listing the scenarios should be 
#   sufficient
#
#   Scenario: Verify that the "From" and "To" details on the Journey Results page match the planned journey
#    Given the user has planned a journey from "<From>" to "<To>"
#    When the journey results are displayed
#    Then the "From" and "To" details on the Journey Results page should match the entered journey details
#
#   Scenario: Verify that the 'Edit Preferences' option toggles with 'Hide Preferences'
#    Given the user is on the journey planning page
#    When the user selects the "Edit Preferences" option
#    Then the "Edit Preferences" option should disappear
#    And the "Hide Preferences" option should be displayed
#    When the user selects the "Hide Preferences" option
#    Then the "Hide Preferences" option should disappear
#    And the "Edit Preferences" option should be displayed
#
#   Scenario: Verify that 'Public Transport', 'Cycling', and 'Walking' tabs are available in Edit Preferences
#    Given the user has selected the "Edit Preferences" option
#    Then the "Public Transport", "Cycling", and "Walking" tabs should be available
#
#   Scenario: Verify the Edit Journey options and window appearance
#    Given the user has planned a journey
#    When the user clicks on the "Edit Journey" link
#    Then the "Edit Journey" window should appear
#
#   Scenario: Verify toggle functionality between "From" and "To" options in Edit Journey
#    Given the "Edit Journey" window is open
#    When the user toggles between the "From" and "To" options
#    Then the selected option should be highlighted as active
#
#   Scenario: Verify updating the journey in Edit Journey window
#    Given the "Edit Journey" window is open
#    When the user updates the "From" location to "<NewFrom>" and the "To" location to "<NewTo>"
#    And the user saves the updated journey
#    Then the journey results should display the updated "From" and "To" locations as "<NewFrom>" and "<NewTo>"
