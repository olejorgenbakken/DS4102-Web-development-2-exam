<template>
  <article class="greeting">
    <h2 class="greeting-text">
      <small>Logget inn som</small>
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
  align-items: flex-end;
  justify-content: center;
}

.greeting-text small {
  font-size: 0.6em;
  margin-bottom: 3px;
  font-weight: 500;
}
</style>