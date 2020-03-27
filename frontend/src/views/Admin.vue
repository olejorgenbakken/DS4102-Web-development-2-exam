<template>
  <section class="admin">
    <TheHeader></TheHeader>
    <header class="header">
      <h2 class="greeting">Velkommen, {{loggedIn.FirstName}}</h2>
    </header>
    <section class="dishes" id="menu-table">
      <h3>Retter på menyen</h3>
      <DishTable></DishTable>
    </section>
    <section class="new-dish">
      <h3>Legg til ny rett</h3>
      <AddNewDish></AddNewDish>
    </section>
  </section>
</template>

<script>
import TheHeader from "../components/TheHeader.vue";
import DishTable from "../components/admin/DishTable.vue";
import AddNewDish from "../components/admin/AddNewDish.vue";

export default {
  name: "AdminHome",
  components: {
    TheHeader,
    DishTable,
    AddNewDish
  },
  data() {
    return {
      loggedIn: {},
      users: [
        { id: 1, Username: "Admin", FirstName: "Siv", LastName: "Jensen" }
      ]
    };
  },
  created() {
    for (let i = 0; i < this.users.length; i++) {
      if (this.$route.params.id == this.users[i].id) {
        this.loggedIn = this.users[i];
      }
    }
  }
};
</script>

<style scoped>
.admin {
  width: 100%;
  max-width: 1200px;
  padding: 0 30px 30px 30px;
  margin: 0 auto;
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}

h2,
h3 {
  font-family: var(--subheading);
}

.new-dish {
  padding: 20px;
  background: var(--color);
}
</style>