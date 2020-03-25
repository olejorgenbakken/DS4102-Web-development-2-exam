<template>
  <div class="admin">
    <TheHeader></TheHeader>
    <section class="content">
      <header class="table-header">
        <h2 class="greeting">Velkommen, {{$route.params.id}}</h2>
      </header>
      <section class="dishes">
        <h3>Retter på menyen</h3>
        <DishTable></DishTable>
      </section>
    </section>
  </div>
</template>

<script>
import TheHeader from "../../components/TheHeader.vue";
import DishTable from "../../components/admin/DishTable.vue";

export default {
  name: "Administration",
  components: {
    TheHeader,
    DishTable
  }
};
</script>

<style scoped>
.content {
  width: 100%;
  max-width: 1200px;
  padding: 30px;
  margin: 0 auto;
}

h2,
h3 {
  font-family: var(--subheading);
}
</style>