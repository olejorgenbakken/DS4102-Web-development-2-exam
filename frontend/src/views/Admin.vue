<template>
  <div class="admin">
    <h1>Welcome, admin</h1>
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