<template>
  <section class="search">
    <input type="search" placeholder="Søk" v-model="term" />
    <select v-model="selected">
      <option disabled selected>Velg type</option>
      <option v-for="type in types" :key="type">{{type}}</option>
    </select>
  </section>
</template>

<script>
export default {
  name: "Search",
  data() {
    return {
      term: "",
      types: ["Alle", "Maki", "Sashimi"],
      selected: ""
    };
  },
  updated() {
    if (this.term != "" && this.selected != "") {
      this.$router.push({
        query: { dish: this.term, type: this.selected }
      });
    } else if (this.selected != "") {
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
  width: 90%;
  margin: 0 auto;
  display: grid;
  grid-template-columns: 1fr 100px;
  gap: 10px;
  height: max-content;
}

select,
input {
  color: black;
  border: 1px solid black;
  border-radius: 10px;
  appearance: unset;
}

input {
  width: 100%;
  padding: 15px;
}
</style>