import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import TodoItemsPage from './components/TodoItemsPage';

export default () => (
  <Layout>
    <Route exact path='/' component={TodoItemsPage} />
  </Layout>
);
