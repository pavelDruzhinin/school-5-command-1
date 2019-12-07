
<template>
  <v-card
    :loading="loading"
    class="mx-auto my-12"
    max-width="374"

  >
    <v-img
      height="300"
      src="https://msanl.nl/wp-content/uploads/2015/04/Echo_user_icon.svg_.png"
    ></v-img>

    <v-card-title></v-card-title>

    <v-card-text>
      <v-row
        align="center"
        class="mx-0"
      >
        <v-rating
          :value="4.5"
          color="amber"
          dense
          half-increments
          readonly
          size="14"
        ></v-rating>

        <div class="grey--text ml-4">4.5 (413)</div>
      </v-row>

      <div class="my-4 subtitle-1 black--text">
    
      </div>
    </v-card-text>

    <v-divider class="mx-4"></v-divider>

    <v-card-title>About me</v-card-title>

    <v-card-text>
      <div>bgfhgfff</div>
      <v-chip-group
        v-model="selection"
        active-class=" accent-4 white--text"
        column
      >
        <v-chip>complited chatbots</v-chip>

        <v-chip>my chatbots</v-chip>
      </v-chip-group>
    </v-card-text>

    <v-card-actions>
      <v-btn
        color="deep-purple accent-4"
        text
        @click="reserve"
      >
        
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

 <script>
   export default {
     data: () => ({
       loading: false,
      selection: 1,
     }),
     methods: {
       reserve () {
         this.loading = true

         setTimeout(() => (this.loading = false), 2000)
       },
     },
   }
 </script>