const requestTodoItemsType = 'REQUEST_TODO_ITEMS';
const receiveTodoItemsType = 'RECEIVE_TODO_ITEMS';
const initialState = { todoItems: [], isLoading: false };

export const actionCreators = {
  requestTodoItems: () => async (dispatch, _) => {    
    dispatch({ type: requestTodoItemsType });

    const url = `api/Todo`;
    const response = await fetch(url);
    const todoItems = await response.json();

    dispatch({ type: receiveTodoItemsType, todoItems });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestTodoItemsType) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === receiveTodoItemsType) {
    return {
      ...state,
      todoItems: action.todoItems,
      isLoading: false
    };
  }

  return state;
};
