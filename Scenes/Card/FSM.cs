using Godot;
using System;
using System.Collections.Generic;

public partial class FSM : Node
{
	[Export] public NodePath InitialState;

	private Dictionary<string, State> _states;
	public State _currentState;
	private static bool _hasPrintedStateNames = false;

	public override void _Ready()
	{
		_states = new Dictionary<string, State>();
		foreach (Node node in GetChildren())
		{
			if (node is State s)
			{
				_states[node.Name] = s;
				s.fsm = this; 
				s.Ready();
				s.Exit();
			}
		}
		if (!_hasPrintedStateNames)
		{
			_hasPrintedStateNames = true;
			PrintStateNames();
		}

		if (_states.TryGetValue(InitialState, out var initialState))
		{
			_currentState = initialState;
			_currentState.Enter();
		}
		else
		{
			throw new InvalidOperationException($"Initial state '{InitialState}' not found in state machine.");
		}
	}
	public string GetStateName()
	{
		return _currentState.GetType().Name;
	}

	private void PrintStateNames()
	{
		foreach (string stateName in _states.Keys)
			{
				GD.Print(stateName);
			}
	}
	public override void _Process(double delta)
	{
		_currentState.Update((float)delta);
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		_currentState.HandleInput(@event);
	}
	public void TransitionTo(string key) {
		if (!_states.ContainsKey(key) || _states[key] == _currentState)
			return;
		_currentState.Exit();
		_currentState = _states[key];
		_currentState.Enter();
	}
}
