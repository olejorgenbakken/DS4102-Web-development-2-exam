<template>
  <article class="dish-types card">
    <h2 class="dish-types-header">
      <label class="label">Kategorier</label>
    </h2>
    <select v-model="dishTypes">
      <option>fe</option>
      <option v-for="type in dishTypes" :key="type">{{type}}</option>
    </select>
  </article>
</template>

<script>
import axios from "axios";
export default {
  name: "DishTypeAdder",
  data() {
    return {
      dishTypes: []
    };
  },
  created() {
    let typesURL = "https://localhost:5001/dishtypes";
    axios.get(typesURL).then(response => {
      this.dishTypes = response.data;
    });
  }
};
</script>

<style scoped>
.dish-types {
  display: flex;
  flex-direction: column;
}
</style>