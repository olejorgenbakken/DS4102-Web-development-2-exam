<template>
  <v-card class="mx-auto my-12" max-width="374" :ingredients="ingredients" :id="'dish-' + id">
    <v-img height="250" :src="photo"></v-img>

    <v-card-title>{{name}}</v-card-title>

    <v-card-text>
      <div>{{description}}</div>
    </v-card-text>

    <v-card-title>Prisinfomrasjon</v-card-title>

    <v-card-text>
      <v-chip-group active-class="deep-purple accent-4 white--text" column>
        <v-chip>Ta med: 1 pakke (8 stk.): {{price}} kr</v-chip>

        <v-chip>Sitte inne: 1 pakke (8 stk.): {{price + 20}} kr</v-chip>

        <v-chip>Ta med: 2 pakker (16 stk.): {{price * 2}} kr</v-chip>

        <v-chip>Sitte inne: 2 pakker (16 stk.): {{price * 2 + 20}} kr</v-chip>
      </v-chip-group>
    </v-card-text>

    <v-card-actions>
      <v-btn color="deep-purple lighten-2" text>Velg</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: "Dish",
  props: {
    id: Number,
    name: String,
    description: String,
    price: Number,
    photo: String,
    ingredients: Array
  }
};
</script>