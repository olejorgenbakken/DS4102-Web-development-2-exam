<template>
  <article class="greeting card">
    <h2 class="greeting-text">
      <label class="label">Logget inn som</label>
      {{firstName}}
    </h2>
  </article>
</template>

<script>
export default {
  name: "Greeting",
  props: {
    firstName: String
  }
};
</script>

<style scoped>
.greeting-text {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: center;
}
</style>