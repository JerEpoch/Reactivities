import React from 'react';
import { Grid } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';
import ActivityDetails from '../details/ActivityDetail';
import ActivityForm from '../form/ActivityForm';
import ActivityList from './ActivityList';

interface Props {
  activities: Activity[];
  selectedActivity: Activity | undefined;
  selectActivity: (id: string) => void;
  cancelSelectActivity: () => void;
  editMode: boolean;
  openForm: (id: string) => void;
  closeForm: () => void;
  createOrEdit: (activity: Activity) => void;
  deleteActivity: (id: string) => void;
}

export default function ActivityDashboard({activities, selectActivity, deleteActivity,
  selectedActivity, cancelSelectActivity, editMode, openForm, closeForm, createOrEdit}: Props) {
  return (
    <Grid>
      <Grid.Column width='10'>
          <ActivityList 
            activities={activities} 
            selectActivity={selectActivity}
            deleteActivity={deleteActivity}
          />
      </Grid.Column>
      <Grid.Column width='6'>
        {/* execute anything to the right of && if not null or undefined */}
        {selectedActivity && !editMode &&
        <ActivityDetails 
          activity={selectedActivity} 
          cancelSelectActivity={cancelSelectActivity}
          openForm={openForm}
        />}
        {editMode && 
        <ActivityForm closeForm={closeForm} activity={selectedActivity} createOrEdit={createOrEdit} />}
      </Grid.Column>
    </Grid>
  )
}