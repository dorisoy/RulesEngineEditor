﻿// Copyright (c) Alex Reich.
// Licensed under the CC BY 4.0 License.

using RulesEngine.Models;
using RulesEngineEditor.Models;
using System;
using System.Collections.Generic;

namespace RulesEngineEditor.Services
{
    public class WorkflowService
    {
        public List<InputRuleParameter> Inputs { get; set; } = new List<InputRuleParameter>();
        public RuleParameter[] RuleParameters { get; set; } = new RuleParameter[0];
        public List<WorkflowData> Workflows { get; set; } = new List<WorkflowData>();

        public event Action OnInputChange;
        public event Action OnWorkflowChange;

        public void InputUpdate()
        {
            OnInputChange.Invoke();
        }

        public void WorkflowUpdate()
        {
            OnWorkflowChange.Invoke();
        }

        public void NewRule(dynamic ruleParent)
        {
            RuleData rule = new RuleData();
            rule.LocalParams = new List<ScopedParamData>();
            if (ruleParent.Rules == null)
            {
                ruleParent.Rules = new List<RuleData>();
            }
            if (ruleParent.GetType() == typeof(RuleData))
            {
                ruleParent.Operator = "And";
            }
            ruleParent.Rules.Insert(0, rule);
            WorkflowUpdate();
        }
    }
}