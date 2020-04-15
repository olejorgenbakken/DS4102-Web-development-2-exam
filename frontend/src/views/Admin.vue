<template>
  <section class="admin">
    <TheHeader></TheHeader>
    <header class="header">
      <h2 class="greeting">Velkommen, {{user.firstName}}</h2>
    </header>
    <DishTable></DishTable>
    <section class="uploads">
      <AddNewDish></AddNewDish>
      <AddAdmin></AddAdmin>
    </section>
  </section>
</template>

<script>
import TheHeader from "../components/TheHeader.vue";
import DishTable from "../components/admin/DishTable.vue";
import AddNewDish from "../components/admin/AddNewDish.vue";
import AddAdmin from "../components/admin/AddAdmin.vue";

export default {
  name: "AdminHome",
  components: {
    TheHeader,
    DishTable,
    AddNewDish,
    AddAdmin
  },
  data() {
    return {
      user: {}
    };
  },
  created() {
    if (sessionStorage.getItem("user") == null) {
      this.$router.push({ name: "Login" });
    } else {
      this.user = JSON.parse(sessionStorage.getItem("user"));
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

.uploads {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}

@media only screen and (min-width: 700px) {
  .uploads {
    grid-template-columns: repeat(2, 1fr);
  }
}
</style>