<template>
  <div class="admin">
    <header class="header">
      <h1 class="headline font-weight-medium">Welcome, admin</h1>
    </header>
    <DishTable></DishTable>
  </div>
</template>

<script>
import DishTable from "../components/admin/DishTable.vue";

export default {
  name: "Administration",
  components: {
    DishTable
  }
};
</script>