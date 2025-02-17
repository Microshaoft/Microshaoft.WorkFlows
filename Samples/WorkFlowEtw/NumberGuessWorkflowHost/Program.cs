﻿namespace NumberGuessWorkflowHost
{
    using Microshaoft;
    using NumberGuessWorkflowActivities;
    //using NumberGuessWorkflowActivities;
    using System;
    using System.Activities;
    using System.Activities.Tracking;
    using System.Collections.Generic;
    using System.Threading;

    class Program
    {
        private const string _xaml = @"
<Activity mc:Ignorable=""sap sap2010 sads"" x:Class=""NumberGuessWorkflowActivities.FlowchartNumberGuessWorkflow"" local:FlowchartNumberGuessWorkflow.MaxNumber=""100""
 xmlns=""http://schemas.microsoft.com/netfx/2009/xaml/activities""
 xmlns:av=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
 xmlns:local=""clr-namespace:NumberGuessWorkflowActivities;NumberGuessWorkflowActivities""

 xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
 xmlns:mca=""clr-namespace:Microsoft.CSharp.Activities;assembly=System.Activities""
 xmlns:sads=""http://schemas.microsoft.com/netfx/2010/xaml/activities/debugger""
 xmlns:sap=""http://schemas.microsoft.com/netfx/2009/xaml/activities/presentation""
 xmlns:sap2010=""http://schemas.microsoft.com/netfx/2010/xaml/activities/presentation""
 xmlns:scg=""clr-namespace:System.Collections.Generic;assembly=mscorlib""
 xmlns:sco=""clr-namespace:System.Collections.ObjectModel;assembly=mscorlib""
 xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
  <x:Members>
    <x:Property Name=""MaxNumber"" Type=""InArgument(x:Int32)"" />
    <x:Property Name=""Turns"" Type=""OutArgument(x:Int32)"" />
  </x:Members>
  <sap2010:ExpressionActivityEditor.ExpressionActivityEditor>C#</sap2010:ExpressionActivityEditor.ExpressionActivityEditor>
  <sap2010:WorkflowViewState.IdRef>NumberGuessWorkflowActivities.FlowchartNumberGuessWorkflow_1</sap2010:WorkflowViewState.IdRef>
  <TextExpression.NamespacesForImplementation>
    <sco:Collection x:TypeArguments=""x:String"">
      <x:String>System</x:String>
      <x:String>System.Collections.Generic</x:String>
      <x:String>System.Data</x:String>
      <x:String>System.Linq</x:String>
      <x:String>System.Text</x:String>
    </sco:Collection>
  </TextExpression.NamespacesForImplementation>
  <TextExpression.ReferencesForImplementation>
    <sco:Collection x:TypeArguments=""AssemblyReference"">
      <AssemblyReference>Microsoft.CSharp</AssemblyReference>
      <AssemblyReference>System</AssemblyReference>
      <AssemblyReference>System.Activities</AssemblyReference>
      <AssemblyReference>System.Core</AssemblyReference>
      <AssemblyReference>System.Data</AssemblyReference>
      <AssemblyReference>System.Runtime.Serialization</AssemblyReference>
      <AssemblyReference>System.ServiceModel</AssemblyReference>
      <AssemblyReference>System.ServiceModel.Activities</AssemblyReference>
      <AssemblyReference>System.Xaml</AssemblyReference>
      <AssemblyReference>System.Xml</AssemblyReference>
      <AssemblyReference>System.Xml.Linq</AssemblyReference>
      <AssemblyReference>mscorlib</AssemblyReference>
      <AssemblyReference>NumberGuessWorkflowActivities</AssemblyReference>
    </sco:Collection>
  </TextExpression.ReferencesForImplementation>
  <Flowchart sap2010:WorkflowViewState.IdRef=""Flowchart_1"">
    <Flowchart.Variables>
      <Variable x:TypeArguments=""x:Int32"" Name=""Guess"" />
      <Variable x:TypeArguments=""x:Int32"" Name=""Target"" />
    </Flowchart.Variables>
    <Flowchart.StartNode>
      <FlowStep x:Name=""__ReferenceID1"" sap2010:WorkflowViewState.IdRef=""FlowStep_5"">
        <Assign sap2010:WorkflowViewState.IdRef=""Assign_1"">
          <Assign.To>
            <OutArgument x:TypeArguments=""x:Int32"">
              <mca:CSharpReference x:TypeArguments=""x:Int32"">Target</mca:CSharpReference>
            </OutArgument>
          </Assign.To>
          <Assign.Value>
            <InArgument x:TypeArguments=""x:Int32"">
              <mca:CSharpValue x:TypeArguments=""x:Int32"">new System.Random().Next(1, MaxNumber + 1)</mca:CSharpValue>
            </InArgument>
          </Assign.Value>
        </Assign>
        <FlowStep.Next>
          <FlowStep x:Name=""__ReferenceID0"" sap2010:WorkflowViewState.IdRef=""FlowStep_4"">
            <local:Prompt BookmarkName=""EnterGuess"" sap2010:WorkflowViewState.IdRef=""Prompt_1"">
              <local:Prompt.Result>
                <OutArgument x:TypeArguments=""x:Int32"">
                  <mca:CSharpReference x:TypeArguments=""x:Int32"">Guess</mca:CSharpReference>
                </OutArgument>
              </local:Prompt.Result>
              <local:Prompt.Text>
                <InArgument x:TypeArguments=""x:String"">
                  <mca:CSharpValue x:TypeArguments=""x:String"">""Please enter a number between 1 and "" + MaxNumber</mca:CSharpValue>
                </InArgument>
              </local:Prompt.Text>
            </local:Prompt>
            <FlowStep.Next>
              <FlowStep x:Name=""__ReferenceID2"" sap2010:WorkflowViewState.IdRef=""FlowStep_3"">
                <Assign sap2010:WorkflowViewState.IdRef=""Assign_2"">
                  <Assign.To>
                    <OutArgument x:TypeArguments=""x:Int32"">
                      <mca:CSharpReference x:TypeArguments=""x:Int32"">Turns</mca:CSharpReference>
                    </OutArgument>
                  </Assign.To>
                  <Assign.Value>
                    <InArgument x:TypeArguments=""x:Int32"">
                      <mca:CSharpValue x:TypeArguments=""x:Int32"">Turns + 1</mca:CSharpValue>
                    </InArgument>
                  </Assign.Value>
                </Assign>
                <FlowStep.Next>
                  <FlowDecision x:Name=""__ReferenceID3"" sap2010:WorkflowViewState.IdRef=""FlowDecision_2"">
                    <FlowDecision.Condition>
                      <mca:CSharpValue x:TypeArguments=""x:Boolean"">Guess == Target</mca:CSharpValue>
                    </FlowDecision.Condition>
                    <FlowDecision.False>
                      <FlowDecision x:Name=""__ReferenceID4"" sap2010:WorkflowViewState.IdRef=""FlowDecision_1"">
                        <FlowDecision.Condition>
                          <mca:CSharpValue x:TypeArguments=""x:Boolean"">Guess &lt; Target</mca:CSharpValue>
                        </FlowDecision.Condition>
                        <FlowDecision.True>
                          <FlowStep x:Name=""__ReferenceID5"" sap2010:WorkflowViewState.IdRef=""FlowStep_1"">
                            <WriteLine sap2010:WorkflowViewState.IdRef=""WriteLine_1"" Text=""Your guess is too low."" />
                            <FlowStep.Next>
                              <x:Reference>__ReferenceID0</x:Reference>
                            </FlowStep.Next>
                          </FlowStep>
                        </FlowDecision.True>
                        <FlowDecision.False>
                          <FlowStep x:Name=""__ReferenceID6"" sap2010:WorkflowViewState.IdRef=""FlowStep_2"">
                            <WriteLine sap2010:WorkflowViewState.IdRef=""WriteLine_2"" Text=""Your guess is too high."" />
                            <FlowStep.Next>
                              <x:Reference>__ReferenceID0</x:Reference>
                            </FlowStep.Next>
                          </FlowStep>
                        </FlowDecision.False>
                      </FlowDecision>
                    </FlowDecision.False>
                  </FlowDecision>
                </FlowStep.Next>
              </FlowStep>
            </FlowStep.Next>
          </FlowStep>
        </FlowStep.Next>
      </FlowStep>
    </Flowchart.StartNode>
    <x:Reference>__ReferenceID1</x:Reference>
    <x:Reference>__ReferenceID0</x:Reference>
    <x:Reference>__ReferenceID2</x:Reference>
    <x:Reference>__ReferenceID3</x:Reference>
    <x:Reference>__ReferenceID4</x:Reference>
    <x:Reference>__ReferenceID5</x:Reference>
    <x:Reference>__ReferenceID6</x:Reference>
    <sads:DebugSymbol.Symbol>d4MBRDpcTXlHaXRIdWJcTWljcm9zaGFvZnQuQ29tbW9uLlV0aWxpdGllcy5OZXQuNHhcU2FtcGxlc1xXb3JrRmxvd0V0d1xOdW1iZXJHdWVzc1dvcmtmbG93QWN0aXZpdGllc1xGbG93Y2hhcnROdW1iZXJHdWVzc1dvcmtmbG93LnhhbWwSAZ0BAaEBAQItA4gBDwIBATQJPxICASdCDU0cAgEbUBFbGgIBEF8XX2UCAQtkG2RrAgEGcB1wdwIBBGgdaHYCAQI8Dzx2AgEtNw83WgIBKEIoQjQCASZKE0qDAQIBIUUTRV0CARxYF1hdAgEWUxdTYQIBEXBbcHQCAQVoW2hzAgED</sads:DebugSymbol.Symbol>
  </Flowchart>
  <sap2010:WorkflowViewState.ViewStateManager>
    <sap2010:ViewStateManager>
      <sap2010:ViewStateData Id=""Assign_1"" sap:VirtualizedContainerService.HintSize=""242,62.6666666666667"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <x:Boolean x:Key=""IsExpanded"">True</x:Boolean>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""Prompt_1"" sap:VirtualizedContainerService.HintSize=""200,22"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <x:Boolean x:Key=""IsExpanded"">True</x:Boolean>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""Assign_2"" sap:VirtualizedContainerService.HintSize=""242,62.6666666666667"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <x:Boolean x:Key=""IsExpanded"">True</x:Boolean>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""WriteLine_1"" sap:VirtualizedContainerService.HintSize=""209.333333333333,62.6666666666667"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <x:Boolean x:Key=""IsExpanded"">True</x:Boolean>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""FlowStep_1"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <av:Point x:Key=""ShapeLocation"">94.5,589</av:Point>
            <av:Size x:Key=""ShapeSize"">209.333333333333,62.6666666666667</av:Size>
            <av:PointCollection x:Key=""ConnectorLocation"">94.5,620 64.5,620 64.5,250.5 199.895,250.5</av:PointCollection>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""WriteLine_2"" sap:VirtualizedContainerService.HintSize=""209.333333333333,62.6666666666667"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <x:Boolean x:Key=""IsExpanded"">True</x:Boolean>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""FlowStep_2"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <av:Point x:Key=""ShapeLocation"">354.5,599</av:Point>
            <av:Size x:Key=""ShapeSize"">209.333333333333,62.6666666666667</av:Size>
            <av:PointCollection x:Key=""ConnectorLocation"">563.833333333333,630.333333333333 593.833333333333,630.333333333333 593.833333333333,250.5 399.895,250.5</av:PointCollection>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""FlowDecision_1"" sap:VirtualizedContainerService.HintSize=""70,86.6666666666667"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <x:Boolean x:Key=""IsExpanded"">True</x:Boolean>
            <av:Point x:Key=""ShapeLocation"">355,496.5</av:Point>
            <av:Size x:Key=""ShapeSize"">70,86.6666666666667</av:Size>
            <av:PointCollection x:Key=""TrueConnector"">355,540 200,540 200,589</av:PointCollection>
            <av:PointCollection x:Key=""FalseConnector"">425,540 460,540 460,599</av:PointCollection>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""FlowDecision_2"" sap:VirtualizedContainerService.HintSize=""70,86.6666666666667"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <x:Boolean x:Key=""IsExpanded"">True</x:Boolean>
            <av:Point x:Key=""ShapeLocation"">264.895,423.5</av:Point>
            <av:Size x:Key=""ShapeSize"">70,86.6666666666667</av:Size>
            <av:PointCollection x:Key=""FalseConnector"">334.895,467 390,467 390,496.5</av:PointCollection>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""FlowStep_3"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <av:Point x:Key=""ShapeLocation"">178.895,311.5</av:Point>
            <av:Size x:Key=""ShapeSize"">242,62.6666666666667</av:Size>
            <av:PointCollection x:Key=""ConnectorLocation"">299.895,373.5 299.895,423.5</av:PointCollection>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""FlowStep_4"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <av:Point x:Key=""ShapeLocation"">199.895,239.5</av:Point>
            <av:Size x:Key=""ShapeSize"">200,22</av:Size>
            <av:PointCollection x:Key=""ConnectorLocation"">299.895,261.5 299.895,311.5</av:PointCollection>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""FlowStep_5"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <av:Point x:Key=""ShapeLocation"">178.895,127.5</av:Point>
            <av:Size x:Key=""ShapeSize"">242,62.6666666666667</av:Size>
            <av:PointCollection x:Key=""ConnectorLocation"">299.895,189.5 299.895,239.5</av:PointCollection>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""Flowchart_1"" sap:VirtualizedContainerService.HintSize=""614,698.666666666667"">
        <sap:WorkflowViewStateService.ViewState>
          <scg:Dictionary x:TypeArguments=""x:String, x:Object"">
            <x:Boolean x:Key=""IsExpanded"">False</x:Boolean>
            <av:Point x:Key=""ShapeLocation"">270,2.5</av:Point>
            <av:Size x:Key=""ShapeSize"">60,74.6666666666667</av:Size>
            <av:PointCollection x:Key=""ConnectorLocation"">300,77.5 300,107.5 299.895,107.5 299.895,127.5</av:PointCollection>
            <x:Double x:Key=""Height"">662.33333333333337</x:Double>
          </scg:Dictionary>
        </sap:WorkflowViewStateService.ViewState>
      </sap2010:ViewStateData>
      <sap2010:ViewStateData Id=""NumberGuessWorkflowActivities.FlowchartNumberGuessWorkflow_1"" sap:VirtualizedContainerService.HintSize=""654,778.666666666667"" />
    </sap2010:ViewStateManager>
  </sap2010:WorkflowViewState.ViewStateManager>
</Activity>
";
        static void Main(string[] args)
        {
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            var inputs = new Dictionary<string, object>() { { "MaxNumber", 100 } };

            //WorkflowApplication wfApp =
            //    new WorkflowApplication(new FlowchartNumberGuessWorkflow());

            /*
            xmlns:local=""clr-namespace:NumberGuessWorkflowActivities;assembly=NumberGuessWorkflowActivities""
            */
            var wfApp = WorkFlowHelper
                            .CreateApplication
                                (
                                    "aa"
                                    , () =>
                                    {
                                        return
                                            _xaml;
                                    }
                                    
                                );
            wfApp.Completed = (e) =>
            {
                int Turns = Convert.ToInt32(e.Outputs["Turns"]);
                Console.WriteLine("Congratulations, you guessed the number in {0} turns.", Turns);

                syncEvent.Set();
            };

            wfApp.Aborted = (e) =>
            {
                Console.WriteLine(e.Reason);
                syncEvent.Set();
            };

            wfApp.OnUnhandledException = (e) =>
            {
                Console.WriteLine(e.UnhandledException.ToString());
                return UnhandledExceptionAction.Terminate;
            };

            wfApp.Idle = (e) =>
            {
                idleEvent.Set();
            };


            var config = @"{
                                ""WorkflowInstanceQuery"" :
                                                            [{
                                                                ""States"":
                                                                            [
                                                                                ""*""
                                                                            ]
                                                                , ""QueryAnnotations"": {}
                                                            }]
                               , ""ActivityStateQuery"" :
                                                            [{
                                                                ""ActivityName"": ""*""
                                                                , ""Arguments"": []
                                                                , ""Variables"": []
                                                                , ""States"": [""*""]
                                                                , ""QueryAnnotations"": {}
                                                            }]
                                ,
                                ""CustomTrackingQuery"": [{
                                                                ""Name"": ""*"",
                                                                ""ActivityName"": ""*"",
                                                                ""QueryAnnotations"": {}
                                                            }]
                                ,
                                ""FaultPropagationQuery"": [{
                                                                ""FaultHandlerActivityName"": ""*"",
                                                                ""FaultSourceActivityName"": ""*"",
                                                                ""QueryAnnotations"": {}
                                                                }],
                                ""BookmarkResumptionQuery"": [{
                                                                    ""Name"": ""*"",
                                                                    ""QueryAnnotations"": {}
                                                                    }],
                                ""ActivityScheduledQuery"": [{
                                                                ""ActivityName"": ""*"",
                                                                ""ChildActivityName"": ""*"",
                                                                ""QueryAnnotations"": {}
                                                                }],
                                ""CancelRequestedQuery"": [{
                                                                ""ActivityName"": ""*"",
                                                                ""ChildActivityName"": ""*"",
                                                                ""QueryAnnotations"": {}
                                                                }]
                            }";
            var trackingProfile = WorkFlowHelper
                                        .GetTrackingProfileFromJson
                                                (
                                                    config
                                                    , true
                                                );
            var etwTrackingParticipant = new EtwTrackingParticipant();
            etwTrackingParticipant.TrackingProfile = trackingProfile;
            var commonTrackingParticipant = new CommonTrackingParticipant()
            {
                TrackingProfile = trackingProfile
                ,
                OnTrackingRecordReceived = (x, y) =>
                                          {
                                              //Console.WriteLine("{1}{0}{2}", ",", x, y);
                                              return true;
                                          }
            };
            
            wfApp
                .Extensions
                .Add
                    (
                        etwTrackingParticipant
                    );
            wfApp
                .Extensions
                .Add
                    (
                        commonTrackingParticipant
                    );

            wfApp.Run();

            // Loop until the workflow completes.
            WaitHandle[] handles = new WaitHandle[] { syncEvent, idleEvent };
            while (WaitHandle.WaitAny(handles) != 0)
            {
                // Gather the user input and resume the bookmark.
                bool validEntry = false;
                while (!validEntry)
                {
                    int Guess;
                    if (!int.TryParse(Console.ReadLine(), out Guess))
                    {
                        Console.WriteLine("Please enter an integer.");
                    }
                    else
                    {
                        validEntry = true;
                        wfApp.ResumeBookmark("EnterGuess", Guess);
                    }
                }
            }
        }
    }
}
