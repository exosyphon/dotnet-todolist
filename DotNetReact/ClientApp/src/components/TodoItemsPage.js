import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/TodoItems';

class TodoItemsPage extends Component {
  constructor(props) {
    super(props);

    this.renderTodoItems = this.renderTodoItems.bind(this)
    this.renderCompleted = this.renderCompleted.bind(this)
  }

  componentWillMount() {
    this.props.requestTodoItems();
  }

  renderTodoItems(todoItems) {
    return (
      <table className="table table-striped table-hover">
        <thead>
          <tr>
            <th scope="col">Description</th>
            <th scope="col">Completed?</th>
          </tr>
        </thead>
        <tbody>
          {todoItems.map(todoItem =>
            <tr key={todoItem.id}>
              <td>{todoItem.name}</td>
              <td>{this.renderCompleted(todoItem.isComplete)}</td>
            </tr>
          )}
        </tbody>
      </table>
    )
  }

  renderCompleted(isComplete) {
    return isComplete ? "✓" : ""
  }

  render() {
    return (
      <div>
        <h1>Todo Items</h1>
        {this.renderTodoItems(this.props.todoItems)}
      </div>
    );
  }
}

export default connect(
  state => state.todoItems,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(TodoItemsPage);
