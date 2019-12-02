<template>
    <v-window>
        <v-row justify="center">
            <v-dialog v-model="dialog" persistent max-width="500px">
                <template v-slot:activator="{ on }">
                    <span v-on="on">Registration</span>
                </template>
                <v-card
                        class="mx-auto"
                        max-width="500"
                >
                    <v-card-title class="title font-weight-regular justify-space-between">
                        <span>{{ currentTitle }}</span>
                        <v-avatar
                                color="primary lighten-2"
                                class="subheading white--text"
                                size="24"
                                v-text="step"
                        ></v-avatar>
                    </v-card-title>

                    <v-window v-model="step">
                        <v-window-item :value="1">
                            <v-card-text>
                                <v-text-field
                                        label="Email"
                                        value="john@vuetifyjs.com"
                                ></v-text-field>
                                <span class="caption grey--text text--darken-1">
            This is the email you will use to login to your SUBs account
          </span>
                            </v-card-text>
                        </v-window-item>

                        <v-window-item :value="2">
                            <v-card-text>
                                <v-text-field
                                        label="Password"
                                        type="password"
                                ></v-text-field>
                                <v-text-field
                                        label="Confirm Password"
                                        type="password"
                                ></v-text-field>
                                <span class="caption grey--text text--darken-1">
            Please enter a password for your account
          </span>
                            </v-card-text>
                        </v-window-item>

                        <v-window-item :value="3">
                            <div class="pa-4 text-center">
                                <v-img
                                        class="mb-4"
                                        contain
                                        height="128"
                                        src="https://cdn.vuetifyjs.com/images/logos/v.svg"
                                ></v-img>
                                <h3 class="title font-weight-light mb-2">Welcome to Vuetify</h3>
                                <span class="caption grey--text">Thanks for signing up!</span>
                            </div>
                        </v-window-item>
                    </v-window>

                    <v-divider></v-divider>

                    <v-card-actions>
                        <v-btn
                                :disabled="step === 1"
                                text
                                @click="step--"
                        >
                            Back
                        </v-btn>
                        <v-spacer></v-spacer>
                        <v-btn
                                :disabled="step === 3"
                                color="primary"
                                depressed
                                @click="step++"
                        >
                            Next
                        </v-btn>
                        <v-spacer></v-spacer>
                        <v-btn
                                color="indigo"
                                @click="reset()"
                               >
                            Close
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-row>
    </v-window>
</template>

<script>
    export default {
        data: () => ({
            step: 1,
            dialog: false,
        }),
        computed: {
            currentTitle () {
                switch (this.step) {
                    case 1: return 'Enter E-mail'
                    case 2: return 'Create a password'
                    default: return 'Account created'
                }
            },
        },
        methods: {
            reset () {
                this.$refs.form.reset();
            },
        }
    }
</script>