<template>
  <form id="new-admin">
    <header>
      <h3>Legg til administrator</h3>
    </header>
  </form>
</template>

<script>
export default {
  name: "NewAdmin"
};
</script>

<style scoped>
#new-admin {
  display: grid;
  grid-template-columns: 1fr;
  width: 100%;
  margin: 0 auto;
}

#new-admin section {
  display: grid;
  grid-template-columns: 1fr;
  font-family: var(--paragraph);
}

header {
  font-family: var(--subheading);
  padding: 20px 0 5px 0;
}
</style>