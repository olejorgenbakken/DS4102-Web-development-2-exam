<template>
  <section class="search">
    <input
      type="search"
      placeholder="Søk"
      :value="searchTerm"
      @input="$emit('input', $event.target.value)"
    />
  </section>
</template>

<script>
export default {
  name: "Search",
  props: {
    searchTerm: String
  }
};
</script>

<style scoped>
.search {
  font-family: var(--heading);
  width: 90%;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  position: relative;
}

.search::after {
  position: absolute;
  bottom: 0;
  left: 0;
  content: "";
  width: 100%;
  height: 2px;
  background: black;
}

.search input {
  width: 100%;
  padding: 15px;
}
</style>