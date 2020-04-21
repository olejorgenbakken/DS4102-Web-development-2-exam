<template>
  <section class="search">
    <input type="search" placeholder="Søk" v-model="term" />
    <select v-model="selected">
      <option disabled selected>Velg type</option>
      <option value="Alle">Alle</option>
      <option v-for="type in dishTypes" :key="type.name">{{type.name}}</option>
    </select>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "Search",
  data() {
    return {
      term: "",
      dishTypes: ["Alle"],
      selected: ""
    };
  },
  created() {
    let dishListURL = `https://localhost:5001/dishtypes`;
    axios.get(dishListURL).then(response => {
      this.dishTypes = response.data;
    });
  },
  updated() {
    if (this.term != "" && this.selected != "") {
      this.$router.push({
        query: { dish: this.term, type: this.selected }
      });
    } else if (this.selected != "" || this.selected != "Alle") {
      console.log(this.selected);
      this.$router.push({
        query: { type: this.selected }
      });
    } else if (this.term != "") {
      this.$router.push({
        query: { dish: this.term }
      });
    } else {
      this.$router.push({});
    }
  }
};
</script>

<style scoped>
.search {
  font-family: var(--heading);
  width: 100%;
  margin: 0 auto;
  display: grid;
  grid-template-columns: 1fr 100px;
  gap: 10px;
  height: max-content;
  border-bottom: 1px solid black;
}

input {
  width: 100%;
  padding: 15px;
}
</style>