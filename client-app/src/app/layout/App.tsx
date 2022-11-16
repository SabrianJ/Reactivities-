import React from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import { observer } from 'mobx-react-lite';
import { Outlet, Route, Routes } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import ActivityForm from '../../features/activities/form/ActivityForm';
import ActivityDetails from '../../features/activities/details/ActivityDetails';

function App() {
  return (
    <>
      <Container style={{ marginTop: '7em' }}>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route
            element={
              <>
                <NavBar />
                <Outlet />
              </>
            }
          >
            <Route path="/activities" element={<ActivityDashboard />} />
            <Route path="/activities/:id" element={<ActivityDetails />} />
            {['/createActivity', '/manage/:id'].map((path) => {
              return (
                <Route
                  key={path}
                  path={path}
                  element={<ActivityForm key={path} />}
                />
              );
            })}
          </Route>
        </Routes>
      </Container>
    </>
  );
}

export default observer(App);
