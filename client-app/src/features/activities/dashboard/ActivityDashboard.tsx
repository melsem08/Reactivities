import { useEffect } from "react";
import { observer } from "mobx-react-lite";
import { Grid, GridColumn } from "semantic-ui-react";
import ActivityList from "./ActivityList";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponents";

export default observer (function ActivityDashboard() {

    const {activityStore} = useStore();
    const {loadActivities, actvityRegistry} = activityStore;

    useEffect(() => {
      if (actvityRegistry.size <= 1) activityStore.loadActivities();
    }, [loadActivities, actvityRegistry.size])
  
    if (activityStore.loadingInitial) return <LoadingComponent content='Loading app...' />

    return (
        <Grid>
            <GridColumn width='10'>
                <ActivityList />
            </GridColumn>
            <GridColumn width='6'>
                <h2>Activity filters</h2>
            </GridColumn>
        </Grid>
    )
})