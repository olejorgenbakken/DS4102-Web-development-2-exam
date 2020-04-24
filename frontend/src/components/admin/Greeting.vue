<template>
  <article class="greeting card">
    <label>Logget inn som</label>
    <h2 class="greeting-text">{{firstName}} {{lastName}}</h2>
  </article>
</template>

<script>
export default {
  name: "Greeting",
  props: {
    firstName: String,
    lastName: String
  }
};
</script>

<style scoped>
.greeting {
  padding: 20px;
  display: flex;
  flex-direction: column;
}
</style>